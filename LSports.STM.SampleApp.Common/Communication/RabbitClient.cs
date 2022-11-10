using LSports.STM.SampleApp.Common.Configurations;
using LSports.STM.SampleApp.Common.Entities;
using LSports.STM.SampleApp.Common.Entities.Messages;
using LSports.STM.SampleApp.Common.Extensions;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using RabbitMQ.Client.Framing.Impl;
using System;

namespace LSports.STM.SampleApp.Common.Communication
{
    public class RabbitClient : IDisposable
    {
        private const int Port = 5672;

        private readonly ClientConfiguration _clientConfiguration;
        private readonly PackageDetails _packageDetails;

        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private long? _lastUpdatedTime;

        public event Action<byte[]> RawMessageReceived;
        public event Action<Message> MessageReceived;

        public event Action ConnectionRecovered;
        public event Action<long?> ConnectionClosed;

        public RabbitClient(ClientConfiguration clientConfiguration, PackageDetails packageDetails)
        {
            _clientConfiguration = clientConfiguration;
            _packageDetails = packageDetails;
        }

        public void Start()
        {
            try
            {
                CreateConnection();
                IModel model = _connection.CreateModel();

                // configure quality of service
                model.BasicQos(prefetchSize: 0, prefetchCount: 1000, global: false);

                EventingBasicConsumer consumer = new EventingBasicConsumer(model);

                // define event to handle message
                consumer.Received += (sender, eventArgs) => HandleDownloadedData(eventArgs.Body);

                // start message consumption
                model.BasicConsume(queue: $"_{_clientConfiguration.PackageId}_", noAck: true, consumer: consumer);
            }
            catch (Exception e)
            {
                throw new ConnectFailureException("Failed to connect to message queue", e);
            }
        }

        public void Stop()
        {
            CloseConnection();
        }

        public void Dispose()
        {
            CloseConnection();
        }

        private void CloseConnection()
        {
            _connection?.Close(0, "Disposing");
        }

        private void CreateConnection()
        {
            ConnectionFactory connectionFactory = CreateConnectionFactory();
            _connection = connectionFactory.CreateConnection();

            if (_connection is AutorecoveringConnection)
            {
                (_connection as AutorecoveringConnection).Recovery += (sender, args) => { ConnectionRecovered?.Invoke(); };
            }

            _connection.ConnectionShutdown += (sender, args) => { ConnectionClosed?.Invoke(_lastUpdatedTime); };
        }

        private ConnectionFactory CreateConnectionFactory()
        {
            if (_connectionFactory != null)
            {
                return _connectionFactory;
            }

            _connectionFactory = new ConnectionFactory
            {
                HostName = _clientConfiguration.RmqServer,
                Port = Port,
                UserName = _clientConfiguration.UserName,
                Password = _clientConfiguration.Password,
                AutomaticRecoveryEnabled = true,
                VirtualHost = _clientConfiguration.VHost,
                RequestedHeartbeat = 580,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(1)
            };

            return _connectionFactory;
        }

        private void HandleDownloadedData(byte[] data)
        {
            if (data != null && data.Length != 0)
            {
                var message = data.Deserialize<Message>(_packageDetails.FormatType);
                _lastUpdatedTime = message.Header.ServerTimestamp;

                RawMessageReceived?.Invoke(data);
                MessageReceived?.Invoke(message);
            }
        }
    }
}

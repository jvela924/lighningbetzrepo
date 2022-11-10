using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using LSports.STM.SampleApp.Common.Communication;
using LSports.STM.SampleApp.Common.Configurations;
using LSports.STM.SampleApp.Common.Entities;
using LSports.STM.SampleApp.Common.Entities.Messages;
using LSports.STM.SampleApp.Common.Enums;

namespace LSports.STM.SampleApp.Runner.Handlers
{
    public class RabbitMqHandler : IDisposable
    {
        #region Private Members

        private readonly ClientConfiguration _clientConfiguration;
        private readonly bool _ignoreKeepAliveMessages;
        private readonly RabbitClient _rabbitClient;

        #endregion

        #region Ctor

        public RabbitMqHandler(
            ClientConfiguration clientConfiguration,
            bool ignoreKeepAliveMessages = false)
        {
            if (clientConfiguration == null)
            {
                throw new ArgumentException("clientConfiguration is null");
            }

            // Create directories to save incoming messages
            Directory.CreateDirectory("Messages");
            Directory.CreateDirectory("KeepAlive");

            _clientConfiguration = clientConfiguration;
            _ignoreKeepAliveMessages = ignoreKeepAliveMessages;

            var formatType = ConfigurationHelper.GetIntValue("formatType");
            _rabbitClient = new RabbitClient(
                _clientConfiguration,
                new PackageDetails { FormatType = (FormatType)formatType });

            // This event will fire when a new message is received from RabbitMQ
            _rabbitClient.MessageReceived += OnMessageReceive;
        }

        #endregion

        #region Public Methods

        public void Run()
        {
            _rabbitClient.Start();
        }

        public void Dispose()
        {
            _rabbitClient?.Dispose();
        }

        #endregion

        #region Private Methods

        private void OnMessageReceive(Message message)
        {
            if (!_ignoreKeepAliveMessages &&
                (message.Header.Type == RequestType.KeepAlive || message.Header.Type == RequestType.Heartbeat))
            {
                File.WriteAllText(
                    $"KeepAlive\\{DateTime.UtcNow.Ticks}_{_clientConfiguration.PackageId}_{message.Header.MsgGuid}.xml",
                    SerializeAsXml(message));
                return;
            }

            if (message.Body == null)
                return;

            var serverTimestamp = message.Header.ServerTimestamp;
            List<int> eventIds;

            if (message.Header.Type == RequestType.OutrightLeague)
            {
                eventIds = message.Body.Competition.SubCompetitions
                    .SelectMany(x => x.Events.Select(c => c.FixtureId).ToList()).ToList();
            }
            else if (message.Header.Type == RequestType.OutrightFixture)
            {
                eventIds = message.Body.Competition.Events.Select(x => x.FixtureId).ToList();
            }
            else
            {
                eventIds = message.Body.Events.Select(x => x.FixtureId).ToList();
            }

            Console.WriteLine(
                $"Message ID: {message.Header.MsgSeq} GUID: {message.Header.MsgGuid} ServerTS: {serverTimestamp} FixtureIds: {string.Join(",", eventIds)}");

            if (!_clientConfiguration.WriteLogFile)
            {
                return;
            }

        File.WriteAllText(
                $"Messages\\{DateTime.UtcNow.Ticks}_{_clientConfiguration.PackageId}_{message.Header.Type}_{message.Header.MsgGuid}.xml",
                SerializeAsXml(message));
        }

        private static string SerializeAsXml(Message msg)
        {
            var xmlSerializer = new XmlSerializer(typeof(Message));
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings
            {
                Indent = true,
                OmitXmlDeclaration = true
            };

            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings))
            {
                xmlSerializer.Serialize(writer, msg, emptyNamepsaces);
                return stream.ToString();
            }
        }

        #endregion
    }
}
using System;
using LSports.STM.SampleApp.Common.Configurations;
using LSports.STM.SampleApp.Runner.Handlers;

namespace LSports.STM.SampleApp.Runner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunRabbitSubscription();
        }

        private static void RunRabbitSubscription()
        {
            // Initialize connection parameters from App.config
            var clientConfiguration = new ClientConfiguration
            {
                UserName = ConfigurationHelper.GetValue("UserName"),
                Password = ConfigurationHelper.GetValue("Password"),
                PackageId = ConfigurationHelper.GetIntValue("PackageId"),
                RmqServer = ConfigurationHelper.GetValue("RmqServer"),
                VHost = ConfigurationHelper.GetValue("VHost"),
                WriteLogFile = bool.Parse(ConfigurationHelper.GetValue("WriteLogFile"))
            };

            // Starting RabbitMQ handler
            using (var rabbitMqHandler = new RabbitMqHandler(clientConfiguration, ignoreKeepAliveMessages: false))
            {
                rabbitMqHandler.Run();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }

            Console.WriteLine("Application aborted");
        }
    }
}

namespace LSports.STM.SampleApp.Common.Configurations
{
    public class ClientConfiguration
    {
        public int PackageId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RmqServer { get; set; }
        public string VHost { get; set; }
        public string PullserviceUrl { get; set; }
        public string ApiServiceUrl { get; set; }
        public bool WriteLogFile { get; set; }
    }
}

using System;

namespace LSports.STM.SampleApp.Common.Exceptions
{
    public class MissingKeyInConfigurationException : Exception
    {
        public MissingKeyInConfigurationException(string message) : base(message)
        {

        }
    }
}

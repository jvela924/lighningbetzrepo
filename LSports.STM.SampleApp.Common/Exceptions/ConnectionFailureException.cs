using System;

namespace LSports.STM.SampleApp.Common.Exceptions
{
    public class ConnectionFailureException : Exception
    {
        public ConnectionFailureException(string message) : base(message)
        {

        }
    }
}

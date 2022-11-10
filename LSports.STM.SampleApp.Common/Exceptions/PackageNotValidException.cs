using System;

namespace LSports.STM.SampleApp.Common.Exceptions
{
    public class PackageNotValidException : Exception
    {
        public PackageNotValidException(string message) : base(message)
        {

        }
    }
}

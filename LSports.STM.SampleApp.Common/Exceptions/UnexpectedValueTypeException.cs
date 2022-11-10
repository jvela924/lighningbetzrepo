using System;

namespace LSports.STM.SampleApp.Common.Exceptions
{
    public class UnexpectedValueTypeException : Exception
    {
        public UnexpectedValueTypeException(string message) : base(message)
        { }
    }
}

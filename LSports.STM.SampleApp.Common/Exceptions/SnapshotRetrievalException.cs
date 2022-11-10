using System;

namespace LSports.STM.SampleApp.Common.Exceptions
{
    public class SnapshotRetrievalException : Exception
    {
        public SnapshotRetrievalException(string message) : base(message)
        { }
    }
}

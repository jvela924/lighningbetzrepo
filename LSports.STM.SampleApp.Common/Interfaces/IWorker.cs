using LSports.STM.SampleApp.Common.Entities;
using LSports.STM.SampleApp.Common.Entities.Messages;
using System;
using System.Collections.Generic;

namespace LSports.STM.SampleApp.Common.Interfaces
{
    public interface IWorker
    {
        /// <summary>
        /// Opens connection to LSports server and starts receiving data
        /// </summary>
        void StartReceiving();

        /// <summary>
        /// Closes connection to LSports server
        /// </summary>
        void StopReceiving();

        /// <summary>
        /// Returns all available data for all events
        /// </summary>
        List<Event> GetAllEvents();

        /// <summary>
        /// Returns all available data for requested fixture specified by fixtureId
        /// </summary>
        Event GetEvent(int fixtureId);

        /// <summary>
        /// Raised on each markets change received, argument is raw xml/json in string representation
        /// </summary>
        event Action<string> RawDataReceived;

        /// <summary>
        /// Raised on each markets change or initial snapshot receieved, argument is deserialized c# object
        /// </summary>
        event Action<Message> MessageReceived;

    }
}

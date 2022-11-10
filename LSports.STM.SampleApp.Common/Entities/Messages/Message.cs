using System;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Entities.Messages
{
    /// <summary>  
    /// Base class for all service message classes
    /// </summary>
    [ProtoContract]
    [XmlType("Message")]
    [Serializable]
    public class Message
    {
        [ProtoMember(1)]
        public Header Header { get; set; }

        [ProtoMember(2)]
        [XmlElement(Type = typeof(Body))]
        public Body Body { get; set; }
    }
}

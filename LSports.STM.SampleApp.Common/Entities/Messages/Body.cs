using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Messages
{
    [ProtoContract]
    public class Body
    {
        [ProtoMember(1)]
        [XmlArrayItem("Event")]
        public List<Event> Events { get; set; }

        [ProtoMember(2)]
        public KeepAlive KeepAlive { get; set; }

        [ProtoMember(3)]
        public PackageDetails PackageDetails { get; set; }

        [ProtoMember(4)]
        public Competition Competition { get; set; }
    }
}

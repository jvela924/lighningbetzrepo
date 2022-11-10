using LSports.STM.SampleApp.Common.Entities.Misc;
using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities
{
    [ProtoContract]
    public class KeepAlive
    {
        [ProtoMember(1)]
        [XmlElement("ActiveEvent")]
        public HashSet<int> ActiveEvents { get; set; }

        [ProtoMember(2)]
        [XmlArrayItem("Data")]
        public List<NameValueContainer> ExtraData { get; set; }

        [ProtoMember(3)]
        [XmlElement("ProviderId")]
        public int? ProviderId { get; set; }
    }
}

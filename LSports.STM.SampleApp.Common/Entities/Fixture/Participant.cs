using LSports.STM.SampleApp.Common.Entities.Misc;
using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Fixture
{
    [ProtoContract]
    public class Participant
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int Id { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public string Name { get; set; }

        [XmlAttribute]
        [ProtoMember(3)]
        public string Position { get; set; }

        [XmlAttribute]
        [ProtoMember(4)]
        public int RotationId { get; set; }
        public bool ShouldSerializeRotationId() => RotationId != 0 && RotationId != -1;

        [XmlAttribute]
        [ProtoMember(5)]
        public int IsActive { get; set; } = -1;
        public bool ShouldSerializeIsActive() => IsActive != -1;

        [XmlArrayItem("ExtraData")]
        [ProtoMember(6)]
        public List<NameValueContainer> ExtraData { get; set; } = new List<NameValueContainer>();
        public bool ShouldSerializeExtraData() => ExtraData != null && ExtraData.Count > 0;
    }
}

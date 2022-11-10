using ProtoBuf;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Livescore
{
    [ProtoContract]
    public class Result
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public string Position { get; set; }

        [XmlText]
        [ProtoMember(2)]
        public string Value { get; set; }
    }
}

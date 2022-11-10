using ProtoBuf;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Fixture
{
    [ProtoContract]
    public class Location
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int Id { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public string Name { get; set; }
    }
}

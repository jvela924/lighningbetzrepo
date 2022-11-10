using ProtoBuf;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Misc
{
    [ProtoContract]
    public class NameValueContainer
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public string Name { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public string Value { get; set; }

        public NameValueContainer()
        {
        }

        public NameValueContainer(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}

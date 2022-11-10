using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Livescore
{
    [ProtoContract]
    public class Period
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int Type { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public bool IsFinished { get; set; }

        [XmlAttribute]
        [ProtoMember(3)]
        public bool IsConfirmed { get; set; }

        [XmlElement("Score")]
        [ProtoMember(4)]
        public List<Result> Results { get; set; }
        public bool ShouldSerializeResults() => Results != null && Results.Count > 0;

        [XmlArrayItem("Incident")]
        [ProtoMember(5)]
        public List<Incident> Incidents { get; set; }
    }
}

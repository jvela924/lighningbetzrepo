using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Livescore
{
    [ProtoContract]
    public class Statistic
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public StatisticType Type { get; set; }

        [XmlElement("Value")]
        [ProtoMember(2)]
        public List<Result> Results { get; set; }
        public bool ShouldSerializeResults() => Results != null && Results.Count > 0;

        [XmlArrayItem("Incident")]
        [ProtoMember(5)]
        public List<Incident> Incidents { get; set; }
    }
}

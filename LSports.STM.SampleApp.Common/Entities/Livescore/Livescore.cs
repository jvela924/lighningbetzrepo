using LSports.STM.SampleApp.Common.Entities.Misc;
using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Livescore
{
    [ProtoContract]
    public class Livescore
    {
        [XmlElement]
        [ProtoMember(1)]
        public Scoreboard Scoreboard { get; set; }

        [XmlArrayItem("Period")]
        [ProtoMember(2)]
        public List<Period> Periods { get; set; }
        public bool ShouldSerializePeriods() => Periods != null && Periods.Count > 0;

        [XmlArrayItem("Statistic")]
        [ProtoMember(3)]
        public List<Statistic> Statistics { get; set; }
        public bool ShouldSerializeStatistics() => Statistics != null && Statistics.Count > 0;

        [XmlArrayItem("Data")]
        [ProtoMember(4)]
        public List<NameValueContainer> LivescoreExtraData { get; set; }
        public bool ShouldSerializeLivescoreExtraData() => LivescoreExtraData != null && LivescoreExtraData.Count > 0;
    }
}

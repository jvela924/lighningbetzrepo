using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Livescore
{
    [ProtoContract]
    public class Scoreboard
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public FixtureStatus Status { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public StatusDescription Description { get; set; }
        public bool ShouldSerializeDescription() => Description != StatusDescription.None;

        [XmlAttribute]
        [ProtoMember(3)]
        public int CurrentPeriod { get; set; }

        [XmlAttribute]
        [ProtoMember(4)]
        public string Time { get; set; }
        public bool ShouldSerializeTime() => !string.IsNullOrEmpty(Time) || Time == "-1";

        [XmlElement("Score")]
        [ProtoMember(5)]
        public List<Result> Results { get; set; }
        public bool ShouldSerializeResults => Results != null && Results.Any();
    }
}

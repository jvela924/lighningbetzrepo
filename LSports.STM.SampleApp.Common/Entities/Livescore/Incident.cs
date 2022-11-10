using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Livescore
{

    /// <summary>  
    /// Incidents log
    /// </summary>
    [ProtoContract]
    public class Incident
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int Period { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public int IncidentType { get; set; }

        [XmlAttribute]
        [ProtoMember(3)]
        public int Seconds { get; set; }

        [XmlAttribute]
        [ProtoMember(4)]
        public string ParticipantPosition { get; set; }

        [XmlAttribute]
        [ProtoMember(5)]
        public string PlayerId { get; set; }
        public bool ShouldSerializePlayerId() => !string.IsNullOrEmpty(PlayerId) && PlayerId != "0";

        [XmlAttribute]
        [ProtoMember(6)]
        public string PlayerName { get; set; }
        public bool ShouldSerializePlayerName() => !string.IsNullOrEmpty(PlayerName);

        [XmlElement("Score")]
        [ProtoMember(7)]
        public List<Result> Results { get; set; }
        public bool ShouldSerializeResults() => Results != null && Results.Count > 0;
    }
}

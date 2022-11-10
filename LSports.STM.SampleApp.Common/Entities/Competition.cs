using System.Collections.Generic;
using System.Xml.Serialization;
using Newtonsoft.Json;
using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Entities
{
    [ProtoContract]
    public class Competition
    {
        [ProtoMember(1)]
        [XmlAttribute]
        public int Id { get; set; }

        [ProtoMember(2)]
        [XmlAttribute]
        public string Name { get; set; }

        [ProtoMember(3)]
        [XmlAttribute]
        public int Type { get; set; }

        [ProtoMember(4)]
        [XmlArray("Competitions")]
        [XmlArrayItem("Competition")]
        [JsonProperty("Competitions")]
        public List<Competition> SubCompetitions { get; set; }
        [ProtoMember(5)]
        [XmlArrayItem("Event")]
        public List<Event> Events { get; set; }
    }

}

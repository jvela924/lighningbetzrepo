using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Markets
{
    [ProtoContract]
    public class Market
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int Id { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public string Name { get; set; }

        [XmlArrayItem("Bet")]
        [ProtoMember(4)]
        public List<Bet> Bets { get; set; }
        [XmlAttribute]
        [ProtoMember(5)]
        public string MainLine { get; set; }
    }
}

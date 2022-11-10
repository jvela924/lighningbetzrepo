using LSports.STM.SampleApp.Common.Consts;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Markets
{
    [ProtoContract]
    public class Provider
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int Id { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public string Name { get; set; }

        [XmlIgnore]
        [ProtoMember(3)]
        public DateTime LastUpdate { get; set; }

        [XmlAttribute(nameof(LastUpdate))]
        [JsonIgnore]
        public string SerializedLastUpdate
        {
            get { return LastUpdate.ToString(Const.DateTimeFormat); }
            set { LastUpdate = DateTime.ParseExact(value, Const.DateTimeFormat, DateTimeFormatInfo.InvariantInfo); }
        }

        [XmlAttribute]
        [ProtoMember(4)]
        public string ProviderFixtureId { get; set; }
        public bool ShouldSerializeProviderFixtureId() => !string.IsNullOrEmpty(ProviderFixtureId);

        [XmlAttribute]
        [ProtoMember(5)]
        public string ProviderLeagueId { get; set; }
        public bool ShouldSerializeProviderLeagueId() => !string.IsNullOrEmpty(ProviderLeagueId);

        [XmlAttribute]
        [ProtoMember(6)]
        public string ProviderMarketId { get; set; }
        public bool ShouldSerializeProviderMarketId() => !string.IsNullOrEmpty(ProviderMarketId);

        [XmlElement("Bet")]
        [ProtoMember(7)]
        public List<Bet> Bets { get; set; }
        public bool ShouldSerializeBets() => Bets != null && Bets.Count > 0;
    }
}

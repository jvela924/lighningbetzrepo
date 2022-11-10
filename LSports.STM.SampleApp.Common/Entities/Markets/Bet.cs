using LSports.STM.SampleApp.Common.Consts;
using LSports.STM.SampleApp.Common.Enums;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Markets
{
    [ProtoContract]
    public class Bet
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public long Id { get; set; }

        [XmlAttribute]
        [ProtoMember(2)]
        public string Name { get; set; }

        [XmlAttribute]
        [ProtoMember(3)]
        public string Line { get; set; }
        public bool ShouldSerializeLine() => !string.IsNullOrEmpty(Line);

        [XmlAttribute]
        [ProtoMember(4)]
        public string BaseLine { get; set; }
        public bool ShouldSerializeBaseLine() => !string.IsNullOrEmpty(BaseLine);

        [XmlAttribute]
        [ProtoMember(5)]
        public BetStatus Status { get; set; }
        public bool ShouldSerializeStatus() => Status != BetStatus.NotSet;

        [XmlAttribute]
        [ProtoMember(6)]
        public string StartPrice { get; set; }
        public bool ShouldSerializeStartPrice() => !string.IsNullOrEmpty(StartPrice) && StartPrice != "0";

        [XmlAttribute]
        [ProtoMember(7)]
        public string Price { get; set; }
        public bool ShouldSerializePrice() => !string.IsNullOrEmpty(Price) && Price != "0";

        [XmlAttribute]
        [ProtoMember(8)]
        public string LayPrice { get; set; }
        public bool ShouldSerializeLayPrice() => !string.IsNullOrEmpty(LayPrice) && LayPrice != "0";

        [XmlAttribute]
        [ProtoMember(9)]
        public string PriceVolume { get; set; }
        public bool ShouldSerializePriceVolume() => !string.IsNullOrEmpty(PriceVolume) && PriceVolume != "0";

        [XmlAttribute]
        [ProtoMember(10)]
        public string LayPriceVolume { get; set; }
        public bool ShouldSerializeLayPriceVolume() => !string.IsNullOrEmpty(LayPriceVolume) && LayPriceVolume != "0";

        [XmlAttribute]
        [ProtoMember(11)]
        public SettlementType Settlement { get; set; }
        public bool ShouldSerializeSettlement() => Settlement != SettlementType.NotSettled;

        [XmlAttribute]
        [ProtoMember(12)]
        public string ProviderBetId { get; set; }
        public bool ShouldSerializeProviderBetId() => !string.IsNullOrEmpty(ProviderBetId);

        [ProtoMember(13)]
        [XmlIgnore]
        public DateTime LastUpdate { get; set; }
        [XmlAttribute(nameof(LastUpdate))]
        [JsonIgnore]
        public string SerializedLastUpdate
        {
            get { return LastUpdate.ToString(Const.DateTimeFormat); }
            set { LastUpdate = DateTime.ParseExact(value, Const.DateTimeFormat, DateTimeFormatInfo.InvariantInfo); }
        }

        [XmlAttribute]
        [ProtoMember(14)]
        public string PriceIN { get; set; }

        [XmlAttribute]
        [ProtoMember(15)]
        public string PriceUS { get; set; }

        [XmlAttribute]
        [ProtoMember(16)]
        public string PriceUK { get; set; }

        [XmlAttribute]
        [ProtoMember(17)]
        public string PriceMA { get; set; }

        [XmlAttribute]
        [ProtoMember(18)]
        public string PriceHK { get; set; }

        [XmlIgnore]
        [ProtoMember(19)]
        public int IsChanged { get; set; } = -1;

        [XmlAttribute]
        [ProtoMember(20)]
        public double Probability { get; set; }
        public bool ShouldSerializeProbability() => Math.Abs(Probability) > 0;

        [XmlAttribute]
        [ProtoMember(21)]
        public int ParticipantId { get; set; }
        public bool ShouldSerializeParticipantId() => Math.Abs(ParticipantId) > 0;

        [XmlAttribute]
        [ProtoMember(22)]
        public string PlayerName { get; set; }
    }
}

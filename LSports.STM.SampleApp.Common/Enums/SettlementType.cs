using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Enums
{
    public enum SettlementType
    {
        [XmlEnum("-1")]
        Cancelled = -1,
        [XmlEnum("0")]
        NotSettled = 0,
        [XmlEnum("1")]
        Loser = 1,
        [XmlEnum("2")]
        Winner = 2,
        [XmlEnum("3")]
        Refund = 3,
        [XmlEnum("4")]
        HalfLost = 4,
        [XmlEnum("5")]
        HalfWon = 5
    }
}
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Enums
{
    public enum BetStatus
    {
        [XmlEnum("0")]
        NotSet = 0,
        [XmlEnum("1")]
        Open = 1,
        [XmlEnum("2")]
        Suspended = 2,
        [XmlEnum("3")]
        Settled = 3
    }
}
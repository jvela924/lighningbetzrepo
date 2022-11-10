using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Enums
{
    public enum FixtureStatus
    {
        [XmlEnum("0")]
        NotSet = 0,
        [XmlEnum("1")]
        NSY = 1,
        [XmlEnum("2")]
        InProgress = 2,
        [XmlEnum("3")]
        Finished = 3,
        [XmlEnum("4")]
        Cancelled = 4,
        [XmlEnum("5")]
        Postponed = 5,
        [XmlEnum("6")]
        Interrupted = 6,
        [XmlEnum("7")]
        Abandoned = 7,
        [XmlEnum("8")]
        LostCoverage = 8,
        [XmlEnum("9")]
        AboutToStart = 9
    }
}

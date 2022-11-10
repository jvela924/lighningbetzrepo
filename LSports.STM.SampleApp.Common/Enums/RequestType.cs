using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Enums
{
    public enum RequestType
    {
        [XmlEnum("1")]
        Fixtures = 1,
        [XmlEnum("2")]
        FixtureLivescore = 2,
        [XmlEnum("3")]
        FixtureMarkets = 3,
        [XmlEnum("31")]
        KeepAlive = 31,
        [XmlEnum("32")]
        Heartbeat = 32,
        [XmlEnum("35")]
        Settlements = 35,
        [XmlEnum("37")]
        OutrightFixture = 37,
        [XmlEnum("38")]
        OutrightLeague = 38,
        [XmlEnum("39")]
        OutrightScore = 39,
        [XmlEnum("40")]
        OutrightLeagueMarket = 40,
        [XmlEnum("41")]
        OutrightFixtureMarket = 41,
        [XmlEnum("42")]
        OutrightSettlements = 42,
    }
}
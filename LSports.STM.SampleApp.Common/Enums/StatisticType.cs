using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Enums
{
    public enum StatisticType
    {
        [XmlEnum("0")]
        NotSet = 0,
        [XmlEnum("1")]
        Corners = 1,
        [XmlEnum("2")]
        ShotsOnTarget = 2,
        [XmlEnum("3")]
        ShotsOffTarget = 3,
        [XmlEnum("4")]
        Attacks = 4,
        [XmlEnum("5")]
        DangerousAttacks = 5,
        [XmlEnum("6")]
        YellowCard = 6,
        [XmlEnum("7")]
        RedCard = 7,
        [XmlEnum("8")]
        Penalties = 8,
        [XmlEnum("9")]
        Goal = 9,
        [XmlEnum("10")]
        Substitutions = 10,
        [XmlEnum("11")]
        Possession = 11,
        [XmlEnum("12")]
        Fouls = 12,
        [XmlEnum("13")]
        FreeKicks = 13,
        [XmlEnum("14")]
        GoalKicks = 14,
        [XmlEnum("15")]
        Offsides = 15,
        [XmlEnum("16")]
        BlockedShots = 16,
        [XmlEnum("17")]
        ThrowIns = 17,
        [XmlEnum("18")]
        WoodworkShots = 18,
        [XmlEnum("19")]
        Clearance = 19,
        [XmlEnum("20")]
        Aces = 20,
        [XmlEnum("21")]
        DoubleFaults = 21,
        [XmlEnum("22")]
        ServicePoints = 22,
        [XmlEnum("23")]
        BreakPoints = 23,
        [XmlEnum("24")]
        OwnGoal = 24,
        [XmlEnum("25")]
        PenaltyGoal = 25,
        [XmlEnum("27")]
        Score = 27,
        [XmlEnum("28")]
        TwoPoints = 28,
        [XmlEnum("29")]
        PCT = 29,
        [XmlEnum("30")]
        ThreePoints = 30,
        [XmlEnum("31")]
        TimeOuts = 31,
        [XmlEnum("32")]
        FreeThrows = 32,
        [XmlEnum("33")]
        Hits = 33,
        [XmlEnum("34")]
        FirstServeWins = 34,
        [XmlEnum("35")]
        Ball = 35,
        [XmlEnum("36")]
        WicketTaken = 36,
        [XmlEnum("37")]
        WideBall = 37,
        [XmlEnum("38")]
        NoBall = 38,
        [XmlEnum("39")]
        LegBye = 39,
        [XmlEnum("40")]
        MissedPenalty = 40,
        [XmlEnum("41")]
        Cards = 41
    }
}
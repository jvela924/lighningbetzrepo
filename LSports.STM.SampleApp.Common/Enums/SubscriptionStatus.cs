using System;
using System.Xml.Serialization;
using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Enums
{
    [ProtoContract]
    [Serializable]
    public enum SubscriptionStatus
    {
        [XmlEnum("0")]
        NotSet = 0,
        [XmlEnum("1")]
        Subscribed = 1,
        [XmlEnum("2")]
        Pending = 2,
        [XmlEnum("3")]
        Unsubscribed = 3,
        [XmlEnum("4")]
        Deleted = 4
    }
}
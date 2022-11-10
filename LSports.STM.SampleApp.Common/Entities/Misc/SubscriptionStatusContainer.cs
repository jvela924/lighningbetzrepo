using System.Xml.Serialization;
using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Entities.Misc
{
    [ProtoContract]
    [XmlType("Subscription")]
    public class SubscriptionStatusContainer
    {
        [ProtoMember(1)]
        public int Type { get; set; }

        [ProtoMember(2)]
        public SubscriptionStatus Status { get; set; }
    }
}
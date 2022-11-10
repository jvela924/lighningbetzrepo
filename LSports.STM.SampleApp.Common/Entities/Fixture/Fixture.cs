using LSports.STM.SampleApp.Common.Entities.Misc;
using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities.Fixture
{
    [ProtoContract]
    public class Fixture
    {
        [ProtoMember(1)]
        public Sport Sport { get; set; }

        [ProtoMember(2)]
        public Location Location { get; set; }

        [ProtoMember(3)]
        public League League { get; set; }

        [ProtoMember(4)]
        public DateTime? StartDate { get; set; }

        [ProtoMember(5)]
        public DateTime LastUpdate { get; set; }

        [ProtoMember(6)]
        public FixtureStatus Status { get; set; }
        public bool ShouldSerializeStatus() => Status != FixtureStatus.NotSet;

        [XmlArrayItem("Participant")]
        [ProtoMember(7)]
        public List<Participant> Participants { get; set; }
        public bool ShouldSerializeParticipants() => Participants != null && Participants.Count > 0;

        [XmlArrayItem("ExtraData")]
        [ProtoMember(8)]
        public List<NameValueContainer> ExtraData { get; set; }
        public bool ShouldSerializeExtraData() => ExtraData != null && ExtraData.Count > 0;

        [XmlAttribute]
        [ProtoMember(9)]
        public string ExternalFixtureId { get; set; }
        public bool ShouldSerializeExternalFixtureId() => !string.IsNullOrEmpty(ExternalFixtureId);


        [ProtoMember(10)]
        public SubscriptionStatusContainer Subscription { get; set; }
    }
}

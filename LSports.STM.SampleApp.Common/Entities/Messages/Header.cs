using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;
using System;

namespace LSports.STM.SampleApp.Common.Entities.Messages
{
    [ProtoContract]
    public class Header
    {
        [ProtoMember(1)]
        public RequestType Type { get; set; }

        [ProtoMember(2)]
        public int? MsgSeq { get; set; }

        [ProtoMember(3)]
        public Guid? MsgGuid { get; set; }

        [ProtoMember(4)]
        public DateTime? CreationDate { get; set; }

        [ProtoMember(5)]
        public long? ServerTimestamp { get; set; }

        [ProtoMember(6)]
        public long? ClientTimestamp { get; set; }

        [ProtoMember(7)]
        public int? Status { get; set; }

        [ProtoMember(8)]
        public string Description { get; set; }
    }
}

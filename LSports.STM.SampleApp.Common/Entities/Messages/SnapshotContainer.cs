using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Entities.Messages
{
    [ProtoContract]
    public class SnapshotContainer
    {
        [ProtoMember(1)]
        public Message Message { get; set; }

        [ProtoMember(2)]
        public FormatType FormatType { get; set; }
    }
}

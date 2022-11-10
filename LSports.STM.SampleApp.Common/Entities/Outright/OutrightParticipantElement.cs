using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Entities.Outright
{
    [ProtoContract]
    public class OutrightParticipantElement
    {
        [ProtoMember(1)]
        public int ParticipantId { get; set; }

        [ProtoMember(2)]
        public string Name{ get; set; }

        [ProtoMember(3)]
        public int Result { get; set; }
        public OutrightParticipantElement()
        {

        }
    }
}

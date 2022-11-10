using System.Collections.Generic;
using System.Xml.Serialization;
using LSports.STM.SampleApp.Common.Enums;
using Newtonsoft.Json;
using ProtoBuf;

namespace LSports.STM.SampleApp.Common.Entities.Outright
{

    [ProtoContract]
    public class OutrightScore
    {
        [ProtoMember(1)]
        [XmlArray(Order = 2)]
        [JsonProperty(Order = 2)]
        [XmlArrayItem("ParticipantResult")]
        public List<OutrightParticipantElement> ParticipantResults { get; set; }

        [ProtoMember(2)]
        [XmlElement(Order = 1)]
        [JsonProperty(Order = 1)]
        public FixtureStatus Status { get; set; }

        public OutrightScore()
        {

        }
    }
}

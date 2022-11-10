using LSports.STM.SampleApp.Common.Entities.Markets;
using ProtoBuf;
using System.Collections.Generic;
using System.Xml.Serialization;
using LSports.STM.SampleApp.Common.Entities.Outright;

namespace LSports.STM.SampleApp.Common.Entities
{
    [ProtoContract]
    public class Event
    {
        [XmlAttribute]
        [ProtoMember(1)]
        public int FixtureId { get; set; }

        [ProtoMember(2)]
        public Fixture.Fixture Fixture { get; set; }

        [ProtoMember(3)]
        public Livescore.Livescore Livescore { get; set; }

        [ProtoMember(4)]
        [XmlArrayItem("Market")]
        public List<Market> Markets { get; set; } = new List<Market>();

        [ProtoMember(5)]
        public OutrightFixture OutrightFixture { get; set; }

        [ProtoMember(6)]
        public OutrightLeague OutrightLeague { get; set; }

        [ProtoMember(7)]
        public OutrightScore OutrightScore { get; set; }
    }
}

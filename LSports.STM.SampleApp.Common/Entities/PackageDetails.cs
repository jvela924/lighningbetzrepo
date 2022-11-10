using LSports.STM.SampleApp.Common.Enums;
using ProtoBuf;
using System;
using System.Xml.Serialization;

namespace LSports.STM.SampleApp.Common.Entities
{
    [ProtoContract]
    [XmlType("PackageDetailsBody")]
    public class PackageDetails
    {
        [ProtoMember(1)]
        public int PackageId { get; set; }
        [ProtoMember(2)]
        public Guid PackageGuid { get; set; }
        [ProtoMember(3)]
        public string Description { get; set; }
        [ProtoMember(4)]
        public bool IsActive { get; set; }
        [ProtoMember(5)]
        public DateTime ExpirationDate { get; set; }
        [ProtoMember(6)]
        public FormatType FormatType { get; set; }
    }
}

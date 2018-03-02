using ProtoBuf;
using System;
namespace Api.Forex.Sharp.Models
{
    [ProtoContract]
    public class CurrencyInfos
    {
        [ProtoMember(1)]
        public string Code { get; set; }
        [ProtoMember(2)]
        public string Symbol { get; set; }
        [ProtoMember(3)]
        public string Name { get; set; }
        [ProtoMember(4)]
        public string Description { get; set; }
        [ProtoMember(5)]
        public string SmallDescription { get; set; }
        [ProtoMember(6)]
        public string Country { get; set; }
        [ProtoMember(7)]
        public string CountryCode { get; set; }
        [ProtoMember(8)]
        public TimeSpan? DailyUpdate { get; set; }
        [ProtoMember(9)]
        public string TimeZone { get; set; }
    }
}

using ProtoBuf;
using System;
using System.Collections.Generic;

namespace Api.Forex.Sharp.Models
{
    [ProtoContract]
    public class ApiForexRates
    {
        [ProtoMember(1)]
        public bool success { get; set; }
        [ProtoMember(2)]
        public ApiErrors error { get; set; }
        [ProtoMember(3)]
        public string terms { get; set; }
        [ProtoMember(4)]
        public string privacy { get; set; }
        [ProtoMember(5)]
        public string legacy { get; set; }
        [ProtoMember(6)]
        public string note { get; set; }
        [ProtoMember(7)]
        public string timestamp { get; set; }
        [ProtoMember(8)]
        public string source { get; set; }
        [ProtoMember(9)]
        public Dictionary<string, decimal> rates { get; set; }
        [ProtoMember(10)]
        public Dictionary<string, Candles> historics { get; set; }
    }
    [ProtoContract]
    public class Candles
    {
        [ProtoMember(1)]
        public Decimal? open { get; set; }
        [ProtoMember(2)]
        public Decimal? high { get; set; }
        [ProtoMember(3)]
        public Decimal? low { get; set; }
        [ProtoMember(4)]
        public Decimal? close { get; set; }
        [ProtoMember(5)]
        public Decimal? volume { get; set; }
        [ProtoMember(6)]
        public Int64 date { get; set; }
    }
}

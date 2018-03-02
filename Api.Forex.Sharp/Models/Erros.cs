using ProtoBuf;

namespace Api.Forex.Sharp.Models
{
    [ProtoContract]
    public class ApiErrors
    {
        [ProtoMember(1)]
        public int code { get; set; }
        [ProtoMember(2)]
        public string message { get; set; }
    }
}

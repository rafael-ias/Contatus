using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Contatus.Core.Responses
{
    public class Response<TData>
    {
        private const int DefaultStatusCode = 200;
        private readonly int _code;

        [JsonConstructor]
        public Response() => _code = DefaultStatusCode;

        public Response(TData? data, int code = DefaultStatusCode, string? message = null)
        {
            Data = data;
            _code = code;
            Message = message;
        }

        public TData? Data { get; set; }
        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code is 200 and <= 299;
    }
}

using FogBugz.Api.JsonApi.Models.Response.Data;

namespace FogBugz.Api.JsonApi.Models.Response
{
    public abstract class ResponseCommon
    {
        public List<string> errors { get; set; } = new();
        public List<string> warnings { get; set; } = new();
        public Meta meta { get; set; } = new();
        public string errorCode { get; set; } = string.Empty;
        public string maxCacheAge { get; set; } = string.Empty;
    }
}

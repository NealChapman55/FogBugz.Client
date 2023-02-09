namespace FogBugz.Api.JsonApi.Models.Request
{
    internal abstract class Authenticated
    {
        public string token { get; set; } = string.Empty;
    }
}

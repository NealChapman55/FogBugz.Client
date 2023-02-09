namespace FogBugz.Api.JsonApi.Models.Response
{
    public sealed class ApiVersion : ResponseCommon
    {
        public Data.ApiVersion data { get; set; } = new();
    }
}

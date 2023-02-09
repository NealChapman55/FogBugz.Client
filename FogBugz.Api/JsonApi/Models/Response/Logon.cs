namespace FogBugz.Api.JsonApi.Models.Response
{
    public sealed class Logon : ResponseCommon
    {
        public Data.Logon data { get; set; } = new();
    }
}

namespace FogBugz.Api.JsonApi.Models.Request
{
    internal sealed class Logon
    {
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}

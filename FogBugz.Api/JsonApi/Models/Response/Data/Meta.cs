namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class Meta
    {
        public string jsdbInvalidator { get; set; } = string.Empty;
        public ClientVersionAllowed clientVersionAllowed { get; set; } = new();
    }
}

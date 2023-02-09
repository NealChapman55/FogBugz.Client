namespace FogBugz.Api.JsonApi.Models.Response
{
    public sealed class ViewCase : ResponseCommon
    {
        public Data.ViewCase data { get; set; } = new();
    }
}

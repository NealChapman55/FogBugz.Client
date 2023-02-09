namespace FogBugz.Api.JsonApi.Models.Response
{
    public sealed class ListProjects : ResponseCommon
    {
        public Data.ListProjects data { get; set; } = new();
    }
}

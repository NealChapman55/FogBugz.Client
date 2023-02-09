namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class ListProjects
    {
        public List<ListProjectsProject> projects { get; set; } = new();
    }
}

namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class ViewCaseCase
    {
        public int ixBug { get; set; }
        public List<string> operations { get; set; } = new();
    }
}

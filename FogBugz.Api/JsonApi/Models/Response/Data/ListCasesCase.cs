namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class ListCasesCase
    {
        public List<string> operations { get; set; } = new();
        public string sProject { get; set; } = string.Empty;
        public string sArea { get; set; } = string.Empty;
        public int ixBug { get; set; }
        public string sTitle { get; set; } = string.Empty;
        public string sPersonAssignedTo { get; set; } = string.Empty;
        public List<Event> events { get; set; } = new();
    }
}

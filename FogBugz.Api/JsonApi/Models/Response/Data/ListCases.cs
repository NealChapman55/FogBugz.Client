namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class ListCases
    {
        public string description { get; set; } = string.Empty;
        public string sFilter { get; set; } = string.Empty;
        public int count { get; set; }
        public int totalHits { get; set; }
        public List<ListCasesCase> cases { get; set; } = new();
    }
}

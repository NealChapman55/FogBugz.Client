namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class FullCaseDetails
    {
        public int count { get; set; }
        public int totalHits { get; set; }
        public List<FullCaseDetailsCase> cases { get; set; } = new();
        public List<FullCaseDetailsEvent> events { get; set; } = new();
        public List<FullCaseDetailsMiniEvent> minievents { get; set; } = new();
    }
}

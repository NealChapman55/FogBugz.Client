namespace FogBugz.Api.JsonApi.Models.Request
{
    internal sealed class FullCaseDetails : Authenticated
    {
        public int q { get; set; }
        public string[] cols { get; set; } = { string.Empty };
    }
}

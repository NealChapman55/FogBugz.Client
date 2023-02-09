namespace FogBugz.Api.JsonApi.Models.Request
{
    internal sealed class ListCases : Authenticated
    {
        public string sFilter { get; set; } = string.Empty;
        public string[] cols { get; set; } = { string.Empty };
        public int max { get; set; }
    }
}

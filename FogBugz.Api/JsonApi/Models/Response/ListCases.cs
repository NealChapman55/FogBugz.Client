namespace FogBugz.Api.JsonApi.Models.Response
{
    public sealed class ListCases : ResponseCommon
    {
        public Data.ListCases data { get; set; } = new();
    }
}

namespace FogBugz.Api.JsonApi.Models.Response
{
    public sealed class FullCaseDetails : ResponseCommon
    {
        public Data.FullCaseDetails data { get; set; } = new();
    }
}

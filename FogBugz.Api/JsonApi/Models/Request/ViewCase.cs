namespace FogBugz.Api.JsonApi.Models.Request
{
    internal sealed class ViewCase : Authenticated
    {
        public int ixBug { get; set; }
    }
}

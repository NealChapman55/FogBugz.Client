namespace FogBugz.Api.JsonApi.Models.Request
{
    internal sealed class ListProjects : Authenticated
    {
        public short fWrite { get; set; }
        public int ixProject { get; set; }
        public short fDeleted { get; set; }
    }
}

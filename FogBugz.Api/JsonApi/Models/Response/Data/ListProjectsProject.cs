namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class ListProjectsProject
    {
        public int ixProject { get; set; }
        public string sProject { get; set; } = string.Empty;
        public int ixPersonOwner { get; set; }
        public string sPersonOwner { get; set; } = string.Empty;
        public string sEmail { get; set; } = string.Empty;
        public string sPhone { get; set; } = string.Empty;
        public bool fInbox { get; set; }
        public int ixWorkflow { get; set; }
        public bool fDeleted { get; set; }
    }
}

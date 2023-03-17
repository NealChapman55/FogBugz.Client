namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class FullCaseDetailsMiniEvent
    {
        public int ixBug { get; set; }
        public int ixBugEvent { get; set; }
        public int evt { get; set; }
        public string sVerb { get; set; } = string.Empty;
        public int ixPerson { get; set; }
        public string sPerson { get; set; } = string.Empty;
        public int ixPersonAssignedTo { get; set; }
        public DateTime dt { get; set; }
        public bool fEmail { get; set; }
        public bool fHTML { get; set; }
        public string sFormat { get; set; } = string.Empty;
        public bool fExternal { get; set; }
        public string sChanges { get; set; } = string.Empty;
        public string evtDescription { get; set; } = string.Empty;
        public List<FullCaseDetailsEventAttachment> rgAttachments { get; set; } = new();
        public string sFrom { get; set; } = string.Empty;
        public string sTo { get; set; } = string.Empty;
        public string sCC { get; set; } = string.Empty;
        public string sBCC { get; set; } = string.Empty;
        public string sReplyTo { get; set; } = string.Empty;
        public string sSubject { get; set; } = string.Empty;
        public DateTime sDate { get; set; }
    }
}

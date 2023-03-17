namespace FogBugz.Api.JsonApi.Models.Response.Data
{
    public sealed class FullCaseDetailsCase
    {
        public int ixBug { get; set; }
        public List<string> operations { get; set; } = new();
        public int ixBugParent { get; set; }
        public List<int> ixBugChildren { get; set; } = new();
        public List<string> tags { get; set; } = new();
        public bool fOpen { get; set; }
        public string sTitle { get; set; } = string.Empty;
        public string sOriginalTitle { get; set; } = string.Empty;
        public string sLatestTextSummary { get; set; } = string.Empty;
        public int ixBugEventLatestText { get; set; }
        public int ixProject { get; set; }
        public string sProject { get; set; } = string.Empty;
        public int ixArea { get; set; }
        public string sArea { get; set; } = string.Empty;
        public int ixPersonAssignedTo { get; set; }
        public string sPersonAssignedTo { get; set; } = string.Empty;
        public string sEmailAssignedTo { get; set; } = string.Empty;
        public int ixPersonOpenedBy { get; set; }
        public int ixPersonResolvedBy { get; set; }
        public int ixPersonClosedBy { get; set; }
        public int ixPersonLastEditedBy { get; set; }
        public int ixStatus { get; set; }
        public int ixBugDuplicates { get; set; }
        public int ixBugOriginal { get; set; }
        public string sStatus { get; set; } = string.Empty;
        public int ixPriority { get; set; }
        public string sPriority { get; set; } = string.Empty;
        public int ixFixFor { get; set; }
        public string sFixFor { get; set; } = string.Empty;
        public DateTime dtFixFor { get; set; }
        public string sVersion { get; set; } = string.Empty;
        public string sComputer { get; set; } = string.Empty;
        public decimal hrsOrigEst { get; set; }
        public decimal hrsCurrEst { get; set; }
        public decimal hrsElapsed { get; set; }
        public int c { get; set; }
        public string sCustomerEmail { get; set; } = string.Empty;
        public int ixMailbox { get; set; }
        public int ixCategory { get; set; }
        public string sCategory { get; set; } = string.Empty;
        public DateTime dtOpened { get; set; }
        public DateTime dtResolved { get; set; }
        public DateTime dtClosed { get; set; }
        public int ixBugEventLatest { get; set; }
        public DateTime dtLastUpdated { get; set; }
        public bool fReplied { get; set; }
        public bool fForwarded { get; set; }
        public string sTicket { get; set; } = string.Empty;
        public int ixDiscussTopic { get; set; }
        public DateTime dtDue { get; set; }
        public string sReleaseNotes { get; set; } = string.Empty;
        public int ixBugEventLastView { get; set; }
        public DateTime dtLastView { get; set; }
        public List<int> ixRelatedBugs { get; set; } = new();
        public string sScoutDescription { get; set; } = string.Empty;
        public string sScoutMessage { get; set; } = string.Empty;
        public bool fScoutStopReporting { get; set; }
        public DateTime dtLastOccurrence { get; set; }
        public bool fSubscribed { get; set; }
        public decimal dblStoryPts { get; set; }
        public int nFixForOrder { get; set; }
    }
}

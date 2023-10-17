using Microsoft.Extensions.Configuration;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //var builder = new ConfigurationBuilder();
        //builder.AddCommandLine(args);

        //var config = builder.Build();

        //Console.WriteLine($"Key1: '{config["Key1"]}'");
        //Console.WriteLine($"Key2: '{config["Key2"]}'");
        //Console.WriteLine($"Key3: '{config["Key3"]}'");
        //Console.WriteLine($"Key4: '{config["Key4"]}'");
        //Console.WriteLine($"Key5: '{config["Key5"]}'");

        Console.WriteLine("Welcome to FogBugz Client!");
        Console.WriteLine("");

        var apiConfig = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        string baseUrl = apiConfig["JsonApiUrl"] ?? string.Empty;
        if (string.IsNullOrEmpty(baseUrl))
            throw new Exception("Base URL setting not found.");

        string token = apiConfig["Token"] ?? string.Empty;
        if (string.IsNullOrEmpty(token))
            throw new Exception("Token setting not found.");

        var client = new FogBugz.Api.JsonApi.FogBugzClient(baseUrl);

        await CheckApiVersion(client);

        await Logon(client, token);

        int caseNumber = 24337;
        //await ViewCase(client, token, caseNumber);
        await ViewCaseDetail(client, token, caseNumber);

        //string filterId = "629";
        //await ViewCasesInFilter(client, token, filterId);

        //await ViewProjects(client, token);
    }

    private static async Task CheckApiVersion(FogBugz.Api.JsonApi.FogBugzClient client)
    {
        Console.WriteLine("Checking API version.");
        
        var response = await client.CheckVersionAsync();
        Console.WriteLine($"API Version: {response.data.version}");
        Console.WriteLine("");
    }

    private static async Task Logon(FogBugz.Api.JsonApi.FogBugzClient client, string token)
    {
        Console.WriteLine("Logging in with existing token.");
        var logon = await client.LogonAsync(token);
        Console.WriteLine($"Logon Token: {logon.data.token}");
        Console.WriteLine("");
    }

    private static async Task ViewCase(FogBugz.Api.JsonApi.FogBugzClient client, string token, int caseNumber)
    {
        Console.WriteLine($"Looking up case number {caseNumber}.");
        var caseData = await client.ViewCaseAsync(caseNumber, token);
        Console.WriteLine($"Found: {caseData.data.@case.ixBug}");
        Console.WriteLine("");
    }

    private static async Task ViewCaseDetail(FogBugz.Api.JsonApi.FogBugzClient client, string token, int caseNumber)
    {
        Console.WriteLine($"Looking up detail for case number {caseNumber}.");
        string[] cols = { "sProject", "sArea", "sTitle", "sStatus", "sPersonAssignedTo", "sPriority", "sCategory", "dtOpened", "dtResolved", "dtClosed", "dtDue", "sReleaseNotes", "ixBugParent", "ixBugChildren", "tags", "sFixFor", "ixRelatedBugs", "events" };
        var caseDetail = await client.FullCaseDetailsAsync(caseNumber, cols, token);

        foreach (var item in caseDetail.data.cases)
        {
            Console.WriteLine($"Project: {item.sProject}");
            Console.WriteLine($"Area: {item.sArea}");
            Console.WriteLine($"Milestone: {item.sFixFor}");
            Console.WriteLine($"Case: {item.ixBug}");
            Console.WriteLine($"Title: {item.sTitle}");
            Console.WriteLine($"Person Assigned To: {item.sPersonAssignedTo}");
            Console.WriteLine($"Status: {item.sStatus}");
            Console.WriteLine($"Priority: {item.sPriority}");
            Console.WriteLine($"Category: {item.sCategory}");
            Console.WriteLine($"Date Opened: {item.dtOpened}");
            Console.WriteLine($"Date Resolved: {item.dtResolved}");
            Console.WriteLine($"Date Closed: {item.dtClosed}");
            Console.WriteLine($"Date Due: {item.dtDue}");
            Console.WriteLine($"Release Notes: {item.sReleaseNotes}");
            Console.WriteLine($"Parent Case: {item.ixBugParent}");
            Console.WriteLine($"Child Cases: {string.Join(',', item.ixBugChildren)}");
            Console.WriteLine($"Tags: {string.Join(',', item.tags)}");
            Console.WriteLine($"Related Cases: {string.Join(',', item.ixRelatedBugs)}");
            
            Console.WriteLine("Events:");

            foreach (var itemEvent in item.events)
            {
                Console.WriteLine($"----{itemEvent.dt} - {itemEvent.sVerb} - {itemEvent.evtDescription}");
                
                if (itemEvent.bEmail)
                {
                    Console.WriteLine($"----From: {itemEvent.sFrom}");
                    Console.WriteLine($"----To: {itemEvent.sTo}");
                    Console.WriteLine($"----Subject: {itemEvent.sSubject}");
                    Console.WriteLine($"----Date: {itemEvent.sDate}");
                    Console.WriteLine($"----Body: {itemEvent.sBodyText}");
                }
                else if (!string.IsNullOrEmpty(itemEvent.s))
                {
                    Console.WriteLine($"----{itemEvent.s}");
                }
                
                Console.WriteLine();
            }
        }

        Console.WriteLine("");
    }

    private static async Task ViewCasesInFilter(FogBugz.Api.JsonApi.FogBugzClient client, string token, string filterId)
    {
        string[] cols = { "sProject", "sArea", "ixBug", "sTitle", "sPersonAssignedTo", "events" };
        Console.WriteLine($"Looking up cases in filter {filterId}.");
        var caseList = await client.ListCasesAsync(filterId, cols, 500, token);
        Console.WriteLine($"Found {caseList.data.cases.Count:N0} cases.");
        foreach (var item in caseList.data.cases)
        {
            Console.WriteLine($"{item.sProject} - {item.sArea} - {item.ixBug} - {item.sTitle} - {item.sPersonAssignedTo}");
            foreach (var evt in item.events)
            {
                Console.WriteLine($"----{evt.dt} - {evt.sVerb} - {evt.s}");
            }
        }
        Console.WriteLine("");
    }

    private static async Task ViewProjects(FogBugz.Api.JsonApi.FogBugzClient client, string token)
    {
        Console.WriteLine("Looking up projects.");
        var projectList = await client.ListProjectsAsync(token);
        Console.WriteLine($"Found {projectList.data.projects.Count:N0} projects.");
        foreach (var item in projectList.data.projects)
        {
            Console.WriteLine($"{item.sProject} - {item.sPersonOwner}");
        }
        Console.WriteLine("");
    }
}

using Microsoft.Extensions.Configuration;

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

Console.WriteLine("Checking API version.");
var client = new FogBugz.Api.JsonApi.FogBugzClient(baseUrl);
var response = await client.CheckVersionAsync();
Console.WriteLine($"API Version: {response.data.version}");
Console.WriteLine("");

Console.WriteLine("Logging in with existing token.");
var logon = await client.LogonAsync(token);
Console.WriteLine($"Logon Token: {logon.data.token}");
Console.WriteLine("");

int caseNumber = 18082;
Console.WriteLine($"Looking up case number {caseNumber}.");
var caseData = await client.ViewCase(caseNumber, token);
Console.WriteLine($"Found: {caseData.data.@case.ixBug}");
Console.WriteLine("");

string filterId = "629";
string[] cols = { "sProject", "sArea", "ixBug", "sTitle", "sPersonAssignedTo", "events" };
Console.WriteLine($"Looking up cases in filter {filterId}.");
var caseList = await client.ListCases(filterId, cols, 500, token);
Console.WriteLine($"Found {caseList.data.cases.Count:N0} cases.");
foreach (var item in caseList.data.cases)
{
    Console.WriteLine($"{item.sProject} - {item.sArea} - {item.ixBug} - {item.sTitle} - {item.sPersonAssignedTo}");
    foreach (var evt in item.events)
    {
        Console.WriteLine($"----{evt.dt} - {evt.sVerb}");
    }
}
Console.WriteLine("");

Console.WriteLine("Looking up projects.");
var projectList = await client.ListProjects(token);
Console.WriteLine($"Found {projectList.data.projects.Count:N0} projects.");
foreach (var item in projectList.data.projects)
{
    Console.WriteLine($"{item.sProject} - {item.sPersonOwner}");
}
Console.WriteLine("");
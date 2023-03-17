using System.Net.Http.Json;

namespace FogBugz.Api.JsonApi
{
    public sealed class FogBugzClient
    {
        private readonly string BaseUrl;

        public FogBugzClient(string baseUrl)
        {
            BaseUrl = baseUrl;
        }

        public async Task<Models.Response.ApiVersion> CheckVersionAsync()
        {
            string request = $"{BaseUrl}.json";
            using var httpClient = GetHttpClient();
            using var response = await httpClient.GetAsync(request);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.ApiVersion? result = await response.Content.ReadFromJsonAsync<Models.Response.ApiVersion>();

            if (result is null)
                return new();

            return result;
        }

        public async Task<Models.Response.Logon> LogonAsync(string token)
        {
            string request = $"{BaseUrl}/logon";
            var parms = new Models.Request.ValidateToken() { token = token };
            using var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsJsonAsync(request, parms);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.Logon? result = await response.Content.ReadFromJsonAsync<Models.Response.Logon>();

            if (result is null)
                return new();

            return result;
        }

        public async Task<Models.Response.Logon> LogonAsync(string email, string password)
        {
            string request = $"{BaseUrl}/logon";
            var parms = new Models.Request.Logon() { email = email, password = password };
            using var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsJsonAsync(request, parms);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.Logon? result = await response.Content.ReadFromJsonAsync<Models.Response.Logon>();

            if (result is null)
                return new();

            return result;
        }

        public async Task<Models.Response.ViewCase> ViewCaseAsync(int caseNumber, string token)
        {
            string request = $"{BaseUrl}/viewCase";
            var parms = new Models.Request.ViewCase() { ixBug = caseNumber, token = token };
            using var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsJsonAsync(request, parms);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.ViewCase? result = await response.Content.ReadFromJsonAsync<Models.Response.ViewCase>();

            if (result is null)
                return new();

            return result;
        }

        public async Task<Models.Response.ListCases> ListCasesAsync(string filterId, string[] cols, int max, string token)
        {
            string request = $"{BaseUrl}/listCases";
            var parms = new Models.Request.ListCases() { sFilter = filterId, cols = cols, max = max, token = token };
            using var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsJsonAsync(request, parms);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.ListCases? result = await response.Content.ReadFromJsonAsync<Models.Response.ListCases>();

            if (result is null)
                return new();

            return result;
        }

        public async Task<Models.Response.ListProjects> ListProjectsAsync(string token)
        {
            string request = $"{BaseUrl}/listProjects";
            var parms = new Models.Request.ListProjects() { fWrite = 0, ixProject = 0, fDeleted = 0, token = token };
            using var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsJsonAsync(request, parms);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.ListProjects? result = await response.Content.ReadFromJsonAsync<Models.Response.ListProjects>();

            if (result is null)
                return new();

            return result;
        }

        public async Task<Models.Response.FullCaseDetails> FullCaseDetailsAsync(int caseNumber, string[] cols, string token)
        {
            string request = $"{BaseUrl}/search";
            var parms = new Models.Request.FullCaseDetails() { q = caseNumber, cols = cols, token = token };
            using var httpClient = GetHttpClient();
            using var response = await httpClient.PostAsJsonAsync(request, parms);

            if (!response.IsSuccessStatusCode)
                return new();

            Models.Response.FullCaseDetails? result = await response.Content.ReadFromJsonAsync<Models.Response.FullCaseDetails>();

            if (result is null)
                return new();

            return result;
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Anything");
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}

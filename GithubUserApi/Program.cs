using System.Text.Json;

Console.WriteLine("Hello, World!");

string username = "<Username>";
string githubApiKey = "<Github_Token>";
using (HttpClient client = new HttpClient())
{
    
    client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.+v3json");
    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {githubApiKey}");
    client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
    client.DefaultRequestHeaders.Add("User-Agent","HttpClientFactory-Sample");

    var response = await client.GetAsync($"https://api.github.com/users/{username}/events");
    var json = await response.Content.ReadAsStringAsync();
    var events = JsonSerializer.Deserialize<JsonElement[]>(json);


    var repoIdName = events
        .Select(e => new
        {
            Id = e.GetProperty("repo").GetProperty("id").GetInt64(), // Using GetInt64 for long IDs
            Name = e.GetProperty("repo").GetProperty("name").GetString()
        })
        .DistinctBy(x => x.Id)
        .ToDictionary(x => x.Id, x => x.Name);

    int commitCount = 0;

    foreach (var eventElemnts in events)
    {
        if (eventElemnts.GetProperty("type").GetString() == "PushEvent")
        {
            if (eventElemnts.GetProperty("payload").TryGetProperty("commits", out JsonElement commitsElement))
            {
                commitCount += commitsElement.GetArrayLength();
            }
        }
    }
    
    foreach (var repo in repoIdName)
    {
       Console.WriteLine($"- Id: {repo.Key}, Name: {repo.Value}"); 
    }
   Console.WriteLine($"\n Total Commits: {commitCount}");
    
}

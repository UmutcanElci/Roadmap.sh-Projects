A C# console application that fetches GitHub user events and displays repository information and commit counts.
Prerequisites

.NET 8.0 SDK
GitHub Personal Access Token

Setup

Clone the repository or create a new directory for your project
Ensure you have the provided .csproj and .cs files in your project directory
Create a GitHub Personal Access Token:

Go to GitHub Settings > Developer settings > Personal access tokens
Generate a new token with the repo and user scopes
Copy the generated token



Configuration
In the code, replace the placeholder values:

Replace <Username> with your GitHub username
Replace <Github_Token> with your GitHub Personal Access Token

Running the Application

Open a terminal in the project directory
Run the following commands:


dotnet restore
dotnet run

Output
The application will display:

A list of repository IDs and names you've interacted with
The total number of commits across all push events

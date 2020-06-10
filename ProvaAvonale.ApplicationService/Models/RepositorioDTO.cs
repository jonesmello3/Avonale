using Newtonsoft.Json;

namespace ProvaAvonale.ApplicationService.Models
{
    public class RepositorioDTO
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("node_id")]
        public string IdNode { get; set; }

        [JsonProperty("name")]
        public string Nome { get; set; }

        [JsonProperty("full_name")]
        public string NomeCompleto { get; set; }

        [JsonProperty("private")]
        public string Privado { get; set; }

        [JsonProperty("owner")]
        public OwnerDTO Owner { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }

        [JsonProperty("description")]
        public string Descricao { get; set; }

        [JsonProperty("fork")]
        public bool Fork { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("forks_url")]
        public string ForksUrl { get; set; }

        [JsonProperty("keys_url")]
        public string KeysUrl { get; set; }

        [JsonProperty("collaborators_url")]
        public string CollaboratorsUrl { get; set; }

        [JsonProperty("team_url")]
        public string TeamsUrl { get; set; }

        [JsonProperty("hooks_url")]
        public string HooksUrl { get; set; }

        [JsonProperty("issue_events_url")]
        public string IssueEventsUrl { get; set; }

        [JsonProperty("events_url")]
        public string EventsUrl { get; set; }

        [JsonProperty("assignees_url")]
        public string AssignessUrl { get; set; }

        [JsonProperty("branches_url")]
        public string BranchesUrl { get; set; }

        [JsonProperty("tags_url")]
        public string TagsUrl { get; set; }

        [JsonProperty("blobs_url")]
        public string BlobsUrl { get; set; }

        [JsonProperty("git_tags_url")]
        public string GitTagsUrl { get; set; }

        [JsonProperty("git_refs_url")]
        public string GitRefsUrl { get; set; }

        [JsonProperty("trees_url")]
        public string TreesUrl { get; set; }

        [JsonProperty("statuses_url")]
        public string StatusesUrl { get; set; }

        [JsonProperty("languages_url")]
        public string LanguagesUrl { get; set; }

        [JsonProperty("stargazers_url")]
        public string StargazersUrl { get; set; }

        [JsonProperty("contributors_url")]
        public string ContributorsUrl { get; set; }

        [JsonProperty("subscribers_url")]
        public string SubscribersUrl { get; set; }

        [JsonProperty("subscripton_url")]
        public string SubscriptionUrl { get; set; }

        [JsonProperty("commits_url")]
        public string CommitsUrl { get; set; }

        [JsonProperty("git_commits_url")]
        public string GitCommitsUrl { get; set; }

        [JsonProperty("comments_url")]
        public string ComentsUrl { get; set; }

        [JsonProperty("issue_coments_url")]
        public string IssueComentsUrl { get; set; }

        [JsonProperty("contents_url")]
        public string ContentsUrl { get; set; }

        [JsonProperty("compare_url")]
        public string CompareUrl { get; set; }

        [JsonProperty("merges_url")]
        public string MergesUrl { get; set; }

        [JsonProperty("archive_url")]
        public string ArchiveUrl { get; set; }

        [JsonProperty("downloads_url")]
        public string DownloadsUrl { get; set; }

        [JsonProperty("issues_url")]
        public string IssuesUrl { get; set; }

        [JsonProperty("pulls_url")]
        public string PullsUrl { get; set; }

        [JsonProperty("milestones_url")]
        public string milestonesUrl { get; set; }

        [JsonProperty("notifications_url")]
        public string NotificationsUrl { get; set; }

        [JsonProperty("labels_url")]
        public string LabelsUrl { get; set; }

        [JsonProperty("releases_url")]
        public string ReleasesUrl { get; set; }

        [JsonProperty("deployments_url")]
        public string DeploymentsUrl { get; set; }
    }
}

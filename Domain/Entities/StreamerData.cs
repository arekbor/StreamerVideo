namespace Domain.Entities;

public class StreamerData
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string AvatarUrl { get; set; }
    public DateTime DownloadedOn { get; set; }
    public string YoutubeName { get; set; }
    public string YoutubeUrl { get; set; }
}

using System.Collections.Generic;

namespace YouTubeVideos;

public class Video
{
    private readonly string _title;
    private readonly string _author;
    private readonly int _lengthSeconds;
    private readonly List<Comment> _comments = new();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public string Title => _title;
    public string Author => _author;
    public int LengthSeconds => _lengthSeconds;

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public IReadOnlyList<Comment> GetComments()
    {
        return _comments.AsReadOnly();
    }
}



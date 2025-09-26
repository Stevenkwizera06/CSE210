namespace YouTubeVideos;

public class Comment
{
    private readonly string _authorName;
    private readonly string _text;

    public Comment(string authorName, string text)
    {
        _authorName = authorName;
        _text = text;
    }

    public string AuthorName => _authorName;
    public string Text => _text;

    public override string ToString()
    {
        return $"{_authorName}: {_text}";
    }
}



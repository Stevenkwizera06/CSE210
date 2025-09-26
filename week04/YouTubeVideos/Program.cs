using YouTubeVideos;

var videos = new List<Video>
{
    new("Desert Safari Vlog", "Aisha Khan", 540),
    new("Tech Review: SmartWatch X", "ByteReview", 780),
    new("DIY Home Garden", "GreenThumb", 620),
    new("City Night Timelapse", "LensCrafter", 300)
};

videos[0].AddComment(new Comment("Omar", "Loved the dune bashing scenes!"));
videos[0].AddComment(new Comment("Lila", "The sunset was breathtaking."));
videos[0].AddComment(new Comment("Sam", "Which tour operator did you use?"));

videos[1].AddComment(new Comment("Nate", "Battery life test was super helpful."));
videos[1].AddComment(new Comment("Priya", "Please compare this with Model Y."));
videos[1].AddComment(new Comment("Dev", "Great camera sample analysis."));

videos[2].AddComment(new Comment("Alex", "The compost tip changed my garden!"));
videos[2].AddComment(new Comment("Mina", "Can you share your soil mix?"));
videos[2].AddComment(new Comment("Ray", "Started a herb garden thanks to you."));

videos[3].AddComment(new Comment("Kim", "Music fits the mood perfectly."));
videos[3].AddComment(new Comment("Lee", "What lens did you use?"));
videos[3].AddComment(new Comment("Sara", "Make a tutorial on timelapses!"));

foreach (var video in videos)
{
    Console.WriteLine($"Title: {video.Title}");
    Console.WriteLine($"Author: {video.Author}");
    Console.WriteLine($"Length: {video.LengthSeconds} seconds");
    Console.WriteLine($"Comments: {video.GetCommentCount()}");
    Console.WriteLine("-- Comments --");
    foreach (var comment in video.GetComments())
    {
        Console.WriteLine(comment.ToString());
    }
    Console.WriteLine(new string('-', 40));
}

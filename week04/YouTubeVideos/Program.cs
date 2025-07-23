using System;

class Program
{
    static void Main(string[] args)
    {
        var videos = new List<Video>();

        var video1 = new Video("Potato", "Nyame", 60 * 68);
        video1.AddComment(new Comment("Nice job", "Human"));
        video1.AddComment(new Comment("Bad job", "Human 2"));
        video1.AddComment(new Comment("Okay job", "Not a human"));
        video1.AddComment(new Comment("Terrible job", "Maybe a human"));
        videos.Add(video1);
        
        var video2 = new Video("Potato returns", "Nyame", 60 * 65);
        video2.AddComment(new Comment("Nice job", "Human :)"));
        video2.AddComment(new Comment("Bad job", "Human"));
        video2.AddComment(new Comment("Okay job", "Tired person"));
        videos.Add(video2);
        
        var video3 = new Video("Potato meets Banana", "Nyame", 60 * 71);
        video3.AddComment(new Comment("Nice job", "Human"));
        video3.AddComment(new Comment("Bad job", "Human 2"));
        video3.AddComment(new Comment("Okay job", "Not a human"));
        videos.Add(video3);
        
        foreach (var video in videos)
        {
            Console.WriteLine();
            video.Display();
        }
    }
}
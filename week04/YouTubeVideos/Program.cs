using System;
using System.Collections.Generic;

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Create Videos and Comments
        Video video1 = new Video("C# Basics Tutorial", "TechWithTim", 600);
        video1.AddComment(new Comment("User1", "Great tutorial!"));
        video1.AddComment(new Comment("User2", "Very helpful."));
        video1.AddComment(new Comment("User3", "Thanks!"));

        Video video2 = new Video("Python Data Analysis", "Corey Schafer", 1200);
        video2.AddComment(new Comment("DataFan", "Excellent explanation."));
        video2.AddComment(new Comment("PythonDev", "Really cleared things up."));
        video2.AddComment(new Comment("Newbie", "This is awesome."));
        video2.AddComment(new Comment("AnotherUser", "Thank you for the video."));

        Video video3 = new Video("JavaScript Web Dev", "Traversy Media", 900);
        video3.AddComment(new Comment("WebCoder", "Perfect for beginners!"));
        video3.AddComment(new Comment("JSUser", "This helped a lot."));
        video3.AddComment(new Comment("FrontendDev", "Very informative."));

        Video video4 = new Video("Java OOP Concepts", "Derek Banas", 1500);
        video4.AddComment(new Comment("JavaMaster", "Very detailed!"));
        video4.AddComment(new Comment("JavaLearner", "I understood it better with this video."));
        video4.AddComment(new Comment("JavaDev", "Thanks for sharing."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        // Display Video Information and Comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine(); // Add a blank line for readability
        }
    }
}
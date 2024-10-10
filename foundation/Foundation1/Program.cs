using System;
using System.Collections.Generic;

// Class that represents a YouTube video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments = new List<Comment>();

    // Method to get the number of comments
    public int GetCommentCount()
    {
        return comments.Count;
    }

    // Method to add a comment to the video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to display comments
    public void DisplayComments()
    {
        foreach (Comment comment in comments)
        {
            Console.WriteLine($"Comment by {comment.Name}: {comment.Text}");
        }
    }

    // Method to display video details
    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        DisplayComments();
        Console.WriteLine();
    }
}

// Class that represents a comment on a YouTube video
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    // Constructor to initialize the comment
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video { Title = "How to Code in C#", Author = "Tech Guru", Length = 600 };
        Video video2 = new Video { Title = "Top 10 Programming Tips", Author = "Code Master", Length = 900 };
        Video video3 = new Video { Title = "Understanding OOP", Author = "Dev Pro", Length = 1200 };

        // Add comments to the first video
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can you explain more about classes?"));

        // Add comments to the second video
        video2.AddComment(new Comment("Dave", "Amazing tips, very useful!"));
        video2.AddComment(new Comment("Eve", "I learned a lot, thanks!"));

        // Add comments to the third video
        video3.AddComment(new Comment("Frank", "OOP is hard but this helped!"));
        video3.AddComment(new Comment("Grace", "Thanks for simplifying this!"));
        video3.AddComment(new Comment("Heidi", "I finally understand inheritance now!"));

        // Create a list of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Iterate through the list of videos and display their information
        foreach (Video video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}

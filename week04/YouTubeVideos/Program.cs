using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    // Comment class
    public class Comment
    {
        public string CommenterName { get; set; }
        public string Text { get; set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }

    // Video class
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }
        private List<Comment> comments = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
        }

        public void AddComment(Comment comment)
        {
            comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return comments.Count;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create videos
            Video video1 = new Video("Product Review: Smartwatch", "TechGuru", 600);
            Video video2 = new Video("Unboxing: Wireless Earbuds", "GadgetWorld", 450);
            Video video3 = new Video("Top 10 Smartphones 2025", "MobileTrends", 900);

            // Add comments to video1
            video1.AddComment(new Comment("Alice", "Great review, very detailed!"));
            video1.AddComment(new Comment("Bob", "I love this smartwatch."));
            video1.AddComment(new Comment("Charlie", "Can you compare it with Apple Watch?"));

            // Add comments to video2
            video2.AddComment(new Comment("Diana", "These earbuds look amazing."));
            video2.AddComment(new Comment("Ethan", "How’s the battery life?"));
            video2.AddComment(new Comment("Fiona", "Thanks for the unboxing!"));

            // Add comments to video3
            video3.AddComment(new Comment("George", "I’m surprised iPhone isn’t #1."));
            video3.AddComment(new Comment("Hannah", "Samsung Galaxy is the best!"));
            video3.AddComment(new Comment("Ian", "Very informative video."));

            // Store videos in a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Display details
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"   {comment.CommenterName}: {comment.Text}");
                }

                Console.WriteLine(new string('-', 40)); // separator
            }
        }
    }
}
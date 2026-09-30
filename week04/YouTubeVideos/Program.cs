using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video();
        video1._title = "C#, more like......Easy...haaaaa....sorry";
        video1._author = "Epic Coder";
        video1._lengthInSeconds = 590;
        video1._comments.Add(new Comment() { _commenter = "John", _commentText = "Great video!" });
        video1._comments.Add(new Comment() { _commenter = "Jane", _commentText = "Super cool! Thanks for sharing!" });

        Video video2 = new Video();
        video2._title = "Top 10 Best boss for farming legendaries";
        video2._author = "Killer6";
        video2._lengthInSeconds = 920;
        video2._comments.Add(new Comment() { _commenter = "Alice", _commentText = "Amazing content!" });
        video2._comments.Add(new Comment() { _commenter = "Bob", _commentText = "I learned a lot from this video!" });

        Video video3 = new Video();
        video3._title = "How to make a Python game in 10 minutes";
        video3._author = "Code Master";
        video3._lengthInSeconds = 600;
        video3._comments.Add(new Comment() { _commenter = "Charlie", _commentText = "Very informative!" });
        video3._comments.Add(new Comment() { _commenter = "David", _commentText = "I followed this tutorial, Now im a Millionaire!" });
        video3._comments.Add(new Comment() { _commenter = "Eve", _commentText = "This tutorial SUCKED!" });

        List<Video> videolist = new List<Video>();
        videolist.Add(video1);
        videolist.Add(video2);
        videolist.Add(video3);
        foreach (Video video in videolist)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lengthInSeconds} seconds");
            Console.WriteLine($"Comment count: {video.GetCommentCount()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"{comment._commenter}: {comment._commentText}");
            }

            Console.WriteLine();
        }
    }
}

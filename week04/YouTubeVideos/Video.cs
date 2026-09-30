public class Video
{
    public string _title;
    public string _author;
    public int _lengthInSeconds;
    public List<Comment> _comments = new List<Comment>();
    public int GetCommentCount()
    {
        return _comments.Count;
    }
    public class getCommentCount
{
    public int GetCommentCount(List<Comment> comments)
    {
        return comments.Count;
    }
}
}
        


namespace Sources.Model
{
    public interface IReplica
    {
        string Text { get; }
        
        bool AuthorFromRight { get; }
    }
}
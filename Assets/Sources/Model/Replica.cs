using System;

namespace Sources.Model
{
    public class Replica
    {
        public string Text { get; }
        
        public bool AuthorFromRight { get; }

        public Replica(string text, bool authorFromRight)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentException("Text cant be empty");
            
            Text = text;
            AuthorFromRight = authorFromRight;
        }
    }
}
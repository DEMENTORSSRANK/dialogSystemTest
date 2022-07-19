using System.Collections.Generic;

namespace Sources.Model
{
    public interface IDialog
    {
        string Title { get; }
        
        IEnumerable<IReplica> Replicas { get; }
    }
}
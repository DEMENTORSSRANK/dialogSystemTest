using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Model
{
    public class Dialog : IDialog
    {
        private readonly IReplica[] _replicas;

        public string Title { get; }
        
        public IEnumerable<IReplica> Replicas =>  _replicas;

        public Dialog(IDialog dialog)
        {
            if (dialog == null)
                throw new ArgumentNullException(nameof(dialog));
            
            if (string.IsNullOrEmpty(dialog.Title))
                throw new ArgumentException("Empty or null title");

            if (dialog.Replicas == null)
                throw new ArgumentNullException(nameof(dialog.Replicas));
            
            Title = dialog.Title;
            _replicas = dialog.Replicas.ToArray();
            
            if (_replicas.Length <= 0)
                throw new ArgumentException("Empty replics");
        }
        
        public Dialog(IReplica[] replicas, string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentException("Empty or null title");

            Title = title;
            _replicas = replicas ?? throw new ArgumentNullException(nameof(replicas));
            if (replicas.Length <= 0)
                throw new ArgumentException("Empty replics");
        }
    }
}
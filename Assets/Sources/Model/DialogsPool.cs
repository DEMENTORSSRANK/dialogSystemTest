using System;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Model
{
    public class DialogsPool
    {
        private readonly Dialog[] _dialogs;

        public IEnumerable<IDialog> Dialogs => _dialogs;
        
        public DialogsPool(IEnumerable<Dialog> dialogs)
        {
            if (dialogs == null)
                throw new ArgumentNullException(nameof(dialogs));
            
            _dialogs = dialogs.ToArray();
        }
    }
}
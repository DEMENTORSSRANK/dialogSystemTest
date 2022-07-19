using System.Linq;
using Sources.Data;
using Sources.Model;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class DialogsInitCompositeRoot : CompositeRoot
    {
        [SerializeField] private DialogsResourcesLoader _dialogsLoader;

        public DialogsPool Pool { get; private set; }

        public override void Compose()
        {
            Pool = new DialogsPool(_dialogsLoader.Load().Select(x => new Dialog(x)));
        }

        public override void Initialize()
        {
            
        }

        public override void Dispose()
        {
            
        }
    }
}
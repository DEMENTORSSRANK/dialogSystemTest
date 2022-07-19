using UnityEngine;

namespace Sources.CompositeRoot
{
    public abstract class CompositeRoot : MonoBehaviour
    {
        public abstract void Compose();

        public abstract void Initialize();

        public abstract void Dispose();
    }
}
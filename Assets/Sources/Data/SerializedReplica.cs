using System;
using Sources.Model;
using UnityEngine;

namespace Sources.Data
{
    [Serializable]
    public struct SerializedReplica : IReplica
    {
        [TextArea] [SerializeField] private string _text;

        [SerializeField] private bool _authorFromRight;

        public string Text => _text;

        public bool AuthorFromRight => _authorFromRight;
    }
}
using System.Collections.Generic;
using System.Linq;
using Sources.Model;
using UnityEngine;

namespace Sources.Data
{
    [CreateAssetMenu(fileName = "New dialog data", menuName = "Game/Dialog", order = 0)]
    public class DialogData : ScriptableObject, IDialog
    {
        [SerializeField] private string _title;

        [SerializeField] private SerializedReplica[] _replicas;

        public string Title => _title;

        public IEnumerable<IReplica> Replicas => _replicas.Select(x => x as IReplica);
    }
}
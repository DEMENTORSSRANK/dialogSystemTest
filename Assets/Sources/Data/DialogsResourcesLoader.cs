using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Model;
using UnityEngine;

namespace Sources.Data
{
    [Serializable]
    public class DialogsResourcesLoader
    {
        [SerializeField] private string _folderName = "Dialogs";

        private IEnumerable<IDialog> _cached;

        public IEnumerable<IDialog> Load()
        {
            if (_cached != null)
                return _cached;

            _cached = Resources.LoadAll<DialogData>(_folderName).Select(x => x as IDialog);

            return _cached;
        }
    }
}
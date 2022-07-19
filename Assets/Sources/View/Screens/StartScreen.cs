using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Model;
using Sources.View.Elements.Start;
using UnityEngine;

namespace Sources.View.Screens
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private DialogOpenButton _dialogOpenPrefab;

        [SerializeField] private Transform _dialogOpenButtonsParent;

        public event Action<IDialog> AnyDialogOpenClicked;
        
        public void InitDialogs(IEnumerable<IDialog> dialogs)
        {
            dialogs.ToList().ForEach(CreateNewButtonForDialog);
        }

        private void CreateNewButtonForDialog(IDialog dialog)
        {
            DialogOpenButton created = Instantiate(_dialogOpenPrefab, _dialogOpenButtonsParent);
            
            created.Init(dialog);

            created.Clicked += delegate(IDialog diaLog)
            {
                AnyDialogOpenClicked?.Invoke(diaLog);
            };
        }
    }
}
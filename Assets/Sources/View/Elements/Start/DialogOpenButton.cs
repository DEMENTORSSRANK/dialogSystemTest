using System;
using Sources.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.Elements.Start
{
    [RequireComponent(typeof(Button))]
    public class DialogOpenButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _titleView;

        private IDialog _cached;
        
        private Button _button;

        public event Action<IDialog> Clicked;

        public void Init(IDialog dialog)
        {
            _cached = dialog;
            
            _titleView.text = dialog.Title;
        }
        
        private void Click()
        {
            Clicked?.Invoke(_cached);
        }
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Click);
        }
    }
}
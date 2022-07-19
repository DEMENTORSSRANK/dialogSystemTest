using System;
using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

namespace Sources.View.Elements.DialogPlay
{
    [Serializable]
    public class ReplicaView
    {
        [SerializeField] private TMP_Text _text;

        [Min(0)] [SerializeField] private float _charDelayView = .001f;

        private StringBuilder _printer = new StringBuilder();

        private string _cached;
        
        private Coroutine _currentPrinting;

        private MonoBehaviour _coroutineHelper;

        public bool PrintingNow => _currentPrinting != null;

        public void SetCoroutineHelper(MonoBehaviour coroutineHelper)
        {
            if (_coroutineHelper != null)
                throw new InvalidOperationException("Coroutine helper alredy was set");
            
            _coroutineHelper = coroutineHelper;
        }
        
        public void StartPrintingText(string text)
        {
            _cached = text;
            
            _currentPrinting = _coroutineHelper.StartCoroutine(PrintingText(text));
        }

        public void PushPrinting()
        {
            if (!PrintingNow)
                throw new InvalidOperationException("Cant push, not printing");

            _text.text = _cached;
            
            _coroutineHelper.StopCoroutine(_currentPrinting);

            _currentPrinting = null;
        }

        private IEnumerator PrintingText(string text)
        {
            var wait = new WaitForSeconds(_charDelayView);

            _printer.Clear();
            
            foreach (char symbol in text)
            {
                _printer.Append(symbol);

                _text.text = _printer.ToString();
                
                yield return wait;
            }

            _currentPrinting = null;
        }
    }
}
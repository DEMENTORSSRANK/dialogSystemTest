using System;
using Sources.Model;
using Sources.View.Screens;

namespace Sources.View.Elements
{
    public class ScreensCompare
    {
        private readonly StartScreen _startScreen;

        private readonly DialogPlayScreen _dialogPlayScreen;

        public ScreensCompare(StartScreen startScreen, DialogPlayScreen dialogPlayScreen)
        {
            _startScreen = startScreen ? startScreen : throw new ArgumentNullException(nameof(startScreen));
            _dialogPlayScreen = dialogPlayScreen ? dialogPlayScreen : throw new ArgumentNullException(nameof(dialogPlayScreen));
        }

        public void Start()
        {
            _startScreen.gameObject.SetActive(true);
            
            _dialogPlayScreen.gameObject.SetActive(false);
        }
        
        public void Initialize()
        {
            _startScreen.AnyDialogOpenClicked += StartScreenOnAnyDialogOpenClicked;
            
            _dialogPlayScreen.End += DialogPlayScreenOnEnd;
        }

        public void Dispose()
        {
            _startScreen.AnyDialogOpenClicked -= StartScreenOnAnyDialogOpenClicked;
            
            _dialogPlayScreen.End -= DialogPlayScreenOnEnd;
        }
        
        private void StartScreenOnAnyDialogOpenClicked(IDialog dialog)
        {
            _dialogPlayScreen.gameObject.SetActive(true);
            
            _startScreen.gameObject.SetActive(false);
            
            _dialogPlayScreen.PlayDialog(dialog);
        }
        
        private void DialogPlayScreenOnEnd()
        {
            _dialogPlayScreen.gameObject.SetActive(false);
            
            _startScreen.gameObject.SetActive(true);
        }
    }
}
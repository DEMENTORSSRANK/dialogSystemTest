using Sources.View.Elements;
using Sources.View.Screens;
using UnityEngine;

namespace Sources.CompositeRoot
{
    public class ScreensCompositeRoot : CompositeRoot
    {
        [SerializeField] private StartScreen _startScreen;

        [SerializeField] private DialogPlayScreen _dialogPlayScreen;

        [SerializeField] private DialogsInitCompositeRoot _dialogs;

        private ScreensCompare _screensCompare;

        public override void Compose()
        {
            _startScreen.InitDialogs(_dialogs.Pool.Dialogs);
            
            _screensCompare = new ScreensCompare(_startScreen, _dialogPlayScreen);
            
            _screensCompare.Start();
        }

        public override void Initialize()
        {
            _screensCompare.Initialize();
        }

        public override void Dispose()
        {
            _screensCompare.Dispose();
        }
    }
}
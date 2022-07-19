using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.Elements.DialogPlay
{
    public class RayCastUpdaterOfText : MonoBehaviour
    {
        [SerializeField] private GameObject _scrollBarVertical;

        [SerializeField] private Graphic _rayCastChanger;
        
        public void OnRectPositionChanged(Vector2 position)
        {
            _rayCastChanger.raycastTarget = _scrollBarVertical.activeSelf;                    
        }

        private void OnEnable()
        {
            OnRectPositionChanged(Vector2.zero);
        }

        private void Start()
        {
            _rayCastChanger.raycastTarget = false;
        }
    }
}
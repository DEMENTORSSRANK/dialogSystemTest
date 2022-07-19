using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.View.Elements.DialogPlay
{
    [Serializable]
    public class AvatarsView
    {
        [SerializeField] private Graphic _left;

        [SerializeField] private Graphic _right;

        [SerializeField] private Color _default = Color.white;

        [SerializeField] private Color _active = Color.green;

        public void UpdateActive(bool isRight)
        {
            Graphic activeAvatar = isRight ? _right : _left;

            Graphic inActiveAvatar = isRight ? _left : _right;
            
            SetAvatarToActiveState(activeAvatar);
            
            SetAvatarToDefaultState(inActiveAvatar);
        }

        public void SetDefaultToAll()
        {
            SetAvatarToDefaultState(_left);
            
            SetAvatarToDefaultState(_right);
        }
        
        private void SetAvatarToDefaultState(Graphic avatar)
        {
            avatar.color = _default;
        }

        private void SetAvatarToActiveState(Graphic avatar)
        {
            avatar.color = _active;
        }
    }
}
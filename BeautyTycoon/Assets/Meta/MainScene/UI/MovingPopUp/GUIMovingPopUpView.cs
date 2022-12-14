using BT.Core.UI.View;
using BT.Meta.Common.UI.GUITextWithImage;

using UnityEngine;

namespace BT.Meta.MainScene.UI.MovingPopUp
{
    public class GUIMovingPopUpView : UIView
    {
        [SerializeField] private GUITextWithImageView _text;

        protected override void OnAwake()
        {
#if DEBUG
            Debug.Assert(_text != null);
#endif
        }

        public void ShowText(string text)
        {
            _text.ShowText(text);
        }
    }
}
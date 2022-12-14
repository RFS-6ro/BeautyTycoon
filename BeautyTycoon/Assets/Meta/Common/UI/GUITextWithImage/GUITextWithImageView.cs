using System;

using BT.Core.UI.View;
using BT.Core.UI.View.Loaders;
using BT.Core.Utils;

using UnityEngine;
using UnityEngine.UI;

namespace BT.Meta.Common.UI.GUITextWithImage
{
    public class GUITextWithImageView : UIView, IUIHandleInput
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _container;
        [SerializeField] private Text _text;

        private AsyncUIImage _image;

        private Action _onClick;

        private void OnEnable()
        {
            AddInputListener();
        }

        private void OnDisable()
        {
            RemoceInputListener();
        }

        private void OnDestroy()
        {
            _image.Dispose();
        }

        public void AddInputListener()
        {
            _button.onClick.AddListener(OnClick);
        }

        public void RemoceInputListener()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        protected override void OnAwake()
        {
#if DEBUG
            Debug.Assert(_button != null);
            Debug.Assert(_container != null);
            Debug.Assert(_text != null);
#endif
            _image = new AsyncUIImage(_container);
        }

        public void ShowWithAction
            (string assetName, string text, Action onClick)
        {
            ShowImage(assetName);
            ShowWithAction(onClick);
            ShowText(text);
        }

        public void ShowWithAction(string assetName, Action onClick)
        {
            ShowImage(assetName);
            ShowWithAction(onClick);
            ShowText(string.Empty);
        }

        public void ShowImage(string assetName)
        {
            _image.ShowAsync(new UIAsyncSpriteLoaderWithName(assetName));
        }

        public void ShowText(string text)
        {
            _text.text = text;
        }

        public void ShowWithAction(Action onClick)
        {
            _onClick = onClick;
        }

        private void OnClick()
        {
            _onClick.SafeInvoke();
        }
    }
}
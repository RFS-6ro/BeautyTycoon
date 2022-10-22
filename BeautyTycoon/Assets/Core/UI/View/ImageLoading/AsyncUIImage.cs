using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace BT.Core.UI.View
{
    public class AsyncUIImage : IDisposable
    {
        private Image _container;

        public AsyncUIImage(Image container)
        {
            _container = container;
        }

        public void ShowAsync(IUIAsyncSpriteLoader loader)
        {
            Dispose();
            
#pragma warning disable CS4014
            loader.LoadImageAsync().ContinueWith(image => _container.sprite = image);
#pragma warning restore CS4014
        }

        public void Dispose()
        {
            Resources.UnloadAsset(_container.sprite);
        }
    }
}
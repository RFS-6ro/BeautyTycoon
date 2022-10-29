using System;

using Cysharp.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

namespace BT.Core.UI.View
{
    public class AsyncUIImage : IDisposable
    {
        private readonly Image _container;

        public AsyncUIImage(Image container)
        {
            _container = container;
        }

        public void Dispose()
        {
            Resources.UnloadAsset(_container.sprite);
        }

        public void ShowAsync(IUIAsyncSpriteLoader loader)
        {
            Dispose();

#pragma warning disable CS4014
            loader.LoadImageAsync()
                .ContinueWith(image => _container.sprite = image);
#pragma warning restore CS4014
        }
    }
}
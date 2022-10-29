using System;
using System.Threading;

using Cysharp.Threading.Tasks;

using UnityEngine;

namespace BT.Core.UI.View.Loaders
{
    public class UIAsyncSpriteLoaderWithName : IUIAsyncSpriteLoader
    {
        private readonly string _name;

        public UIAsyncSpriteLoaderWithName(string name)
        {
            _name = name;
        }

        /// <summary>
        ///     Non Cancellable
        /// </summary>
        public async UniTask<Sprite> LoadImageAsync
            (CancellationToken? token = null)
        {
            try
            {
                var request = Resources.LoadAsync<Sprite>(_name);
                await request;
                return (Sprite)request.asset;
            }
            catch (Exception e)
            {
#if DEBUG
                Debug.LogError
                (
                    $"{GetType().Name} :: Exception in resource loading : {e}"
                );
#endif
                return null;
            }
        }
    }
}
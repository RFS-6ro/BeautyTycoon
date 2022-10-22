using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace BT.Core.UI.View
{
    public interface IUIAsyncSpriteLoader
    {
        UniTask<Sprite> LoadImageAsync(CancellationToken? token = null);
    }
}
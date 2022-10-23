using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.UI.Input;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        public readonly Canvas UI;
        public readonly CanvasInputListener CanvasInputListener;
        
        public MainSceneUIStartup()
        {
            UI = Object.Instantiate(Resources.Load<Canvas>("Canvas"));
            CanvasInputListener = UI.GetComponentInChildren<CanvasInputListener>();
        }
        
        public MainSceneUIStartup AddUpdateSystems(EcsSystems systems)
        {
            
            return this;
        }
    }
}

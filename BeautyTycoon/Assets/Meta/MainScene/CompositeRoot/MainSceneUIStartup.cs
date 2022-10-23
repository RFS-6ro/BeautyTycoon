using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.UI.Input;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        public MainSceneUIStartup()
        {
            UI = Resources.Load<Canvas>("Canvas");
            CanvasInputListener = UI.GetComponentInChildren<CanvasInputListener>();
        }
        
        public Canvas UI { get; private set; }
        public CanvasInputListener CanvasInputListener { get; private set; }
        
        public MainSceneUIStartup AddUpdateSystems(EcsSystems systems)
        {
            
            return this;
        }
    }
}

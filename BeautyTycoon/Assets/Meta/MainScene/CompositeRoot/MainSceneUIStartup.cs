using BT.Meta.MainScene.UI.TopBar;
using Core.CompositeRoot;
using Leopotam.Ecs;
using Meta.Common.Environment;
using Meta.Common.UI.Input;
using Meta.MainScene.UI.MovingPopUp;
using Meta.MainScene.UI.ResultWindow;
using Meta.MainScene.UI.VisitorChoseMenu;
using UnityEngine;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        private readonly MetricsConfiguration _metrics;
        private readonly Camera _camera;
        
        public readonly Canvas UI;
        public readonly PanelTouchInputListener PanelTouchInputListener;
        public readonly GUITopBarView GUITopBarView;
        public readonly GUIVisitorChoiceMenuView GUIVisitorChoiceMenuView;
        public readonly GUIResultWindowView GUIResultWindowView;
        public readonly GUIMovingPopUpView GUIMovingPopUpView;
        
        public MainSceneUIStartup(MetricsConfiguration metrics, Camera camera)
        {
            _metrics = metrics;
            _camera = camera;
            
            UI = Object.Instantiate(Resources.Load<Canvas>("Canvas"));
            PanelTouchInputListener = UI.GetComponentInChildren<PanelTouchInputListener>();
            GUITopBarView = UI.GetComponentInChildren<GUITopBarView>();
            GUIVisitorChoiceMenuView = UI.GetComponentInChildren<GUIVisitorChoiceMenuView>();
            GUIResultWindowView = UI.GetComponentInChildren<GUIResultWindowView>();
            GUIMovingPopUpView = UI.GetComponentInChildren<GUIMovingPopUpView>();
        }
        
        public MainSceneUIStartup AddUpdateSystems(EcsSystems systems)
        {
            systems
                .Add(new SGUITopBarPresenter())
                .Add(new SGUIVisitorChoicePresenter())
                .Add(new SGUIResultWindowPresenter())
                .Add(new SGUIMovingPopUpPresenter())
                .Inject(PanelTouchInputListener.GetComponent<RectTransform>())
                .Inject(GUITopBarView)
                .Inject(GUIVisitorChoiceMenuView)
                .Inject(GUIResultWindowView)
                .Inject(GUIMovingPopUpView)
                .Inject(_metrics)
                .Inject(_camera);
            return this;
        }
    }
}

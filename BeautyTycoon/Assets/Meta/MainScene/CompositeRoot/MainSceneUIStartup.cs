using BT.Core.CompositeRoot;
using BT.Meta.Common.Environment;
using BT.Meta.Common.UI.Input;
using BT.Meta.MainScene.UI.MovingPopUp;
using BT.Meta.MainScene.UI.ResultWindow;
using BT.Meta.MainScene.UI.TopBar;
using BT.Meta.MainScene.UI.VisitorChoseMenu;

using Leopotam.Ecs;

using UnityEngine;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class
        MainSceneUIStartup : IUpdateLogicPartStartup<MainSceneUIStartup>
    {
        private readonly Camera _camera;
        private readonly MetricsConfiguration _metrics;
        public readonly GUIMovingPopUpView GUIMovingPopUpView;
        public readonly GUIResultWindowView GUIResultWindowView;
        public readonly GUITopBarView GUITopBarView;
        public readonly GUIVisitorChoiceMenuView GUIVisitorChoiceMenuView;
        public readonly PanelTouchInputListener PanelTouchInputListener;

        public readonly Canvas UI;

        public MainSceneUIStartup(MetricsConfiguration metrics, Camera camera)
        {
            _metrics = metrics;
            _camera = camera;

            UI = Object.Instantiate(Resources.Load<Canvas>("Canvas"));
            PanelTouchInputListener =
                UI.GetComponentInChildren<PanelTouchInputListener>();
            GUITopBarView = UI.GetComponentInChildren<GUITopBarView>();
            GUIVisitorChoiceMenuView =
                UI.GetComponentInChildren<GUIVisitorChoiceMenuView>();
            GUIResultWindowView =
                UI.GetComponentInChildren<GUIResultWindowView>();
            GUIMovingPopUpView =
                UI.GetComponentInChildren<GUIMovingPopUpView>();
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
                .Inject(_camera)
                .Inject(_metrics);
            return this;
        }
    }
}
using BT.Core.CompositeRoot;

namespace BT.Meta.MainScene.CompositeRoot
{
    public class MainSceneEcsStartup : EcsStartupBase
    {
        protected override void AddLogicParts()
        {
            var mainSceneEnvironmentStartup =
                new MainSceneEnvironmentStartup();

            var mainSceneUnitsStartup =
                new MainSceneUnitsStartup();

            var mainSceneUIStartup =
                new MainSceneUIStartup
                (
                    mainSceneEnvironmentStartup.Metrics,
                    mainSceneEnvironmentStartup.Camera
                );

            var mainSceneManagersStartup =
                new MainSceneManagersStartup
                (
                    mainSceneUIStartup.PanelTouchInputListener,
                    mainSceneEnvironmentStartup.Camera
                );

            var mainSceneInputHandlingStartup =
                new MainSceneInputHandlingStartup
                    (mainSceneUIStartup.PanelTouchInputListener);

            var mainSceneMovementStartup =
                new MainSceneMovementStartup
                (
                    mainSceneEnvironmentStartup.Camera,
                    mainSceneEnvironmentStartup.Grid,
                    mainSceneEnvironmentStartup.Mask
                );

            mainSceneManagersStartup
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems)
                .AddLateUpdateSystems(_lateUpdateSystems);

            mainSceneEnvironmentStartup
                .AddUpdateSystems(_updateSystems);

            mainSceneUnitsStartup
                .AddUpdateSystems(_updateSystems);

            mainSceneInputHandlingStartup
                .AddUpdateSystems(_updateSystems);

            mainSceneMovementStartup
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems);

            mainSceneUIStartup
                .AddUpdateSystems(_updateSystems);
        }
    }
}
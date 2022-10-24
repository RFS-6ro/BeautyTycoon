using Core.CompositeRoot;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEcsStartup : EcsStartupBase
    {
        protected override void AddLogicParts()
        {
            MainSceneEnvironmentStartup mainSceneEnvironmentStartup = 
                new MainSceneEnvironmentStartup();
            
            MainSceneUnitsStartup mainSceneUnitsStartup = 
                new MainSceneUnitsStartup();
            
            MainSceneUIStartup mainSceneUIStartup = 
                new MainSceneUIStartup(mainSceneEnvironmentStartup.Metrics);
            
            MainSceneManagersStartup mainSceneManagersStartup =
                new MainSceneManagersStartup(mainSceneUIStartup.PanelTouchInputListener);
            
            MainSceneInputHandlingStartup mainSceneInputHandlingStartup = 
                new MainSceneInputHandlingStartup(mainSceneUIStartup.PanelTouchInputListener);
            
            MainSceneMovementStartup mainSceneMovementStartup = 
                new MainSceneMovementStartup(mainSceneManagersStartup.Camera, mainSceneEnvironmentStartup.Grid, mainSceneEnvironmentStartup.Mask);
            
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

using Core.CompositeRoot;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEcsStartup : EcsStartupBase
    {
        protected override void AddLogicParts()
        {
            MainSceneManagersStartup MainSceneManagersStartup =
                new MainSceneManagersStartup();
            
            MainSceneEnvironmentStartup MainSceneEnvironmentStartup = 
                new MainSceneEnvironmentStartup();
            
            MainSceneUnitsStartup MainSceneUnitsStartup = 
                new MainSceneUnitsStartup();
            
            MainSceneUIStartup MainSceneUIStartup = 
                new MainSceneUIStartup(MainSceneEnvironmentStartup.Metrics);
            
            MainSceneInputHandlingStartup MainSceneInputHandlingStartup = 
                new MainSceneInputHandlingStartup(MainSceneUIStartup.PanelTouchInputListener);
            
            MainSceneMovementStartup MainSceneMovementStartup = 
                new MainSceneMovementStartup(MainSceneManagersStartup.Camera, MainSceneEnvironmentStartup.Grid, MainSceneEnvironmentStartup.Mask);
            
            MainSceneManagersStartup
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems)
                .AddLateUpdateSystems(_lateUpdateSystems);

            MainSceneEnvironmentStartup
                .AddUpdateSystems(_updateSystems);
            
            MainSceneUnitsStartup
                .AddUpdateSystems(_updateSystems);

            MainSceneInputHandlingStartup
                .AddUpdateSystems(_updateSystems);
            
            MainSceneMovementStartup
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems);

            MainSceneUIStartup
                .AddUpdateSystems(_updateSystems);
        }
    }
}

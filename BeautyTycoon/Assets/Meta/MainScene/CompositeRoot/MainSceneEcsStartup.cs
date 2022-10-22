using Core.CompositeRoot;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEcsStartup : EcsStartupBase
    {
        protected override void AddLogicParts()
        {
            MainSceneUIStartup uiStartup = new MainSceneUIStartup();
            
            new MainSceneManagersStartup()
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems)
                .AddLateUpdateSystems(_lateUpdateSystems);

            new MainSceneEnvironmentStartup()
                .AddUpdateSystems(_updateSystems);
            
            new MainSceneUnitsStartup()
                .AddUpdateSystems(_updateSystems);

            new MainSceneInputHandlingStartup(uiStartup.CanvasInputListener)
                .AddUpdateSystems(_updateSystems);
            
            new MainSceneMovementStartup()
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems);

            uiStartup
                .AddUpdateSystems(_updateSystems);
        }
    }
}

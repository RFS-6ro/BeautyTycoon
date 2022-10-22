using Core.CompositeRoot;

namespace Meta.MainScene.CompositeRoot
{
    public class MainSceneEcsStartup : EcsStartupBase
    {
        protected override void AddLogicParts()
        {
            new MainSceneManagersStartup()
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems)
                .AddLateUpdateSystems(_lateUpdateSystems);

            new MainSceneEnvironmentStartup()
                .AddUpdateSystems(_updateSystems);
            
            new MainSceneUnitsStartup()
                .AddUpdateSystems(_updateSystems);

            new MainSceneInputHandlingStartup()
                .AddUpdateSystems(_updateSystems);
            
            new MainSceneMovementStartup()
                .AddUpdateSystems(_updateSystems)
                .AddFixedUpdateSystems(_fixedUpdateSystems);

            new MainSceneUIStartup()
                .AddUpdateSystems(_updateSystems);
        }
    }
}

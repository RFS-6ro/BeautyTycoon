using Leopotam.Ecs;
using UnityEngine.SceneManagement;

namespace Meta.MainScene.SceneReloader
{
    public class SSceneReloader : IEcsRunSystem
    {
        private EcsFilter<CReloadSceneRequest> _filter;
        
        public void Run()
        {
            foreach (var entityId in _filter)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
            }
        }
    }
}

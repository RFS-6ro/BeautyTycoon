using Leopotam.Ecs;

namespace Core.CompositeRoot
{
    public interface IUpdateLogicPartStartup<T> : ILogicPart
        where T : IUpdateLogicPartStartup<T>
    {
        T AddUpdateSystems(EcsSystems systems);
    }
}
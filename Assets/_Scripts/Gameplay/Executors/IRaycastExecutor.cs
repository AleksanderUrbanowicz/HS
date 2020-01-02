using Assets._Scripts.Data.Containers;

namespace Assets._Scripts.Gameplay.Executors
{
    public interface IRaycastExecutor : IUpdateExecutor
    {
        void Init(RaycastData raycastData);

        void GetHitInfo();
    }
}
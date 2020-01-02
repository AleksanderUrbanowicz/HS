namespace Assets._Scripts.Gameplay.MonoBehaviourHookups
{
    public interface IMonoBehaviourable
    {
        void MonoBehaviourAwake();
        void Start();
        void Update();
        void FixedUpdate();
    }
}
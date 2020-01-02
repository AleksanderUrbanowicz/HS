using UnityEngine;

namespace Assets._Scripts.Gameplay.Managers
{
    public interface IScriptableManager
    {
        void Initialize(GameObject obj);
        void LoadState();
        void SaveState();

    }
}
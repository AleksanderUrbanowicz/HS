using UnityEngine;

namespace Managers
{
    public interface IScriptableManager
    {
        void Initialize(GameObject obj);
        void LoadState();
        void SaveState();

    }
}
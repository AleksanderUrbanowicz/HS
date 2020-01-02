using Assets._Scripts.Gameplay.MonoBehaviourHookups;
using UnityEngine;
namespace Assets._Scripts.Gameplay.Helpers
{
    public interface ISpawner
    {
        GameObject CreateInstance(Transform parent, Vector3 position, Quaternion rotation, ISpawnable spawnable = null);
    }
}
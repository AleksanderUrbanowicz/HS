using UnityEngine;
namespace Assets._Scripts.Gameplay.MonoBehaviourHookups
{

    public interface ISpawnable
    {
        GameObject GetPrefab { get; }

        string GetID { get; }
    }
}
using Assets._Scripts.Gameplay.MonoBehaviourHookups;
using UnityEngine;

namespace Assets._Scripts.Data.Containers
{
    [CreateAssetMenu]

    public class PluggableRuntimeCollection : RuntimeCollection<PluggableMonoBehaviour>
    { }
}
using UnityEngine;

namespace Assets._Scripts.Gameplay.MonoBehaviourHookups
{
    public class MonoBehaviourHookup : MonoBehaviour
    {
        public IMonoBehaviourable Parent;
        public void Awake() { if (Parent != null) Parent.MonoBehaviourAwake(); }
        public void Start() { if (Parent != null) Parent.Start(); }
        public void Update() { if (Parent != null) Parent.Update(); }
        public void FixedUpdate() { if (Parent != null) Parent.FixedUpdate(); }
    }
}
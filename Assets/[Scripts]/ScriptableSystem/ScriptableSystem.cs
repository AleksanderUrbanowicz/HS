using UnityEngine;

namespace ScriptableSystems
{
    public abstract class ScriptableSystem : ScriptableObject
    {
        public string id;

        public bool initializeOnStart;

        public MonoBehaviour monoBehaviourScript;
        
        private ScriptableEvent OnStartEvent;
        private ScriptableEvent OnStopEvent;
        public virtual void Initialize(GameObject obj)
        {
            obj.name = id;

          
        }
        
    }
}

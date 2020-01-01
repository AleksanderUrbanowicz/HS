﻿using StateMachine;
using UnityEngine;

namespace ScriptableData
{
   // [CreateAssetMenu]
    public abstract  class ScriptableSystem : ScriptableObject, IScriptableManager
    {
        public string id;

        public bool initializeOnStart;

        public virtual void Initialize(GameObject obj)
        {
            obj.name = id;

        }

        public void LoadState()
        {
        }

        public void SaveState()
        {
        }
    }
}

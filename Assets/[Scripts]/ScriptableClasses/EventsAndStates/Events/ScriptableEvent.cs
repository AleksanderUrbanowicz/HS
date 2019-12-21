using System.Collections.Generic;
using UnityEngine;

namespace StateMachine
{

    [CreateAssetMenu(fileName = "ScriptableEvent", menuName = "States/Scriptable Event")]

    public class ScriptableEvent : ScriptableObject
    {
        public string id;
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<ScriptableEventListener> eventListeners =
            new List<ScriptableEventListener>();

        public virtual void Raise()
        {
            if (eventListeners.Count == 0)
            {

                Debug.Log("Raise(): eventListeners.Count==0, returning");
                return;
            }
            for (int i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised();
        }

        public virtual void RegisterListener(ScriptableEventListener listener)
        {
            if (!eventListeners.Contains(listener))
                eventListeners.Add(listener);
        }

        public virtual void UnregisterListener(ScriptableEventListener listener)
        {
            if (eventListeners.Contains(listener))
                eventListeners.Remove(listener);
        }
    }
}


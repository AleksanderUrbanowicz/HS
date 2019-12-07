// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.Events;

namespace ScriptableSystems
{
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        private void OnEnable()
        {
            if (Event == null)
            {

                Debug.Log("GameEventListener:  Event == null");
                Destroy(this);
            }
            else
            {
                Event.RegisterListener(this);
            }
        }

        private void OnDisable()
        {
            if (Event != null)
            {
                Event.UnregisterListener(this);
            }
        }

        public void OnEventRaised()
        {
            Log();
            if (Response != null)
            {
                Response.Invoke();
                Debug.Log("GameEventListener.OnEventRaised().Invoke: " + Event.name);
            }
            else
            {

                Debug.Log("GameEventListener.OnEventRaised().No Response: " + Event.name);

            }
        }

        public void Log()
        {

            Debug.LogWarning("GameEventListener.Log() name: " + gameObject.name);
        }
    }
}
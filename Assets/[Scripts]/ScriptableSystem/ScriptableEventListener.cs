

using UnityEngine;
using UnityEngine.Events;

namespace ScriptableSystems
{
    public class ScriptableEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public ScriptableEvent Event;

        [Tooltip("Response to invoke when Event is raised.")]
        public UnityEvent Response;

        public void Validate()
        {
            if (Event == null)
            {

                Debug.Log("GameEventListener:  Event == null");
                //   Destroy(this);
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
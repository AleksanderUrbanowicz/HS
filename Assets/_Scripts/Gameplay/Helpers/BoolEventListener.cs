using Assets._Scripts.StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Scripts.Gameplay.Helpers
{
    public class BoolEventListener
    {
        public string id;
        public ScriptableEventListener scriptableEventListenerOnTrue;
        public ScriptableEventListener scriptableEventListenerOnFalse;

        public BoolEventListener(string _id, Transform _parent, ScriptableEvent _eventTrue, UnityAction _responseTrue, ScriptableEvent _eventFalse, UnityAction _responseFalse)
        {

            id = _id;
            scriptableEventListenerOnTrue = new GameObject(id + "True").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnTrue.gameObject.transform.parent = _parent;
            scriptableEventListenerOnTrue.Response = new UnityEngine.Events.UnityEvent();
            scriptableEventListenerOnTrue.Event = _eventTrue;
            scriptableEventListenerOnTrue.Response.AddListener(_responseTrue);
            scriptableEventListenerOnTrue.Validate();

            scriptableEventListenerOnFalse = new GameObject(id + "False").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnFalse.gameObject.transform.parent = _parent;
            scriptableEventListenerOnFalse.Response = new UnityEngine.Events.UnityEvent();
            scriptableEventListenerOnFalse.Event = _eventFalse;
            scriptableEventListenerOnFalse.Response.AddListener(_responseFalse);
            scriptableEventListenerOnFalse.Validate();


        }

        public string Log()
        {

            return "ScriptableEventsBoolGroup_" + id;
        }
    }
}
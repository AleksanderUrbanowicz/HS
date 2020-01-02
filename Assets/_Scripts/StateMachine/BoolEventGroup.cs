using System;

namespace Assets._Scripts.StateMachine
{
    [Serializable]
    public class BoolEventGroup
    {
        public string id;
        public ScriptableEvent scriptableEventTrue;
        public ScriptableEvent scriptableEventFalse;


        public BoolEventGroup(ScriptableEvent _scriptableEventTrue, ScriptableEvent _scriptableEventFalse)
        {
            scriptableEventTrue = _scriptableEventTrue;
            scriptableEventFalse = _scriptableEventFalse;
        }
    }
}

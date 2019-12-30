using UnityEngine;
namespace StateMachine.Actions

{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateControllerMBBase controller);
        public int interval;
    }
}
using UnityEngine;
namespace StateMachine.Decisions
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateControllerMBBase controller);
    }
}
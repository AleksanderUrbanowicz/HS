using UnityEngine;
namespace StateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateControllerMBBase controller);
    }
}
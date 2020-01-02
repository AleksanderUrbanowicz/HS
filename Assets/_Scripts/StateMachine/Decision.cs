using UnityEngine;
namespace Assets._Scripts.StateMachine
{
    public abstract class Decision : ScriptableObject
    {
        public abstract bool Decide(StateControllerMBBase controller);
    }
}
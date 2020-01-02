
using UnityEngine;
namespace Assets._Scripts.StateMachine

{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateControllerMBBase controller);
        public int interval;
    }
}
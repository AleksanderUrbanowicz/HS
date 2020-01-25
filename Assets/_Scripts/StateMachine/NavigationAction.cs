using BaseLibrary.StateMachine;

namespace StateMachine
{
    public abstract class NavigationAction : Action
    {
        public abstract void Act(NavigationStateController controller);
    }
}
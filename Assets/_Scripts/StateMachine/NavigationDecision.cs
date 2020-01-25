using BaseLibrary.StateMachine;
namespace StateMachine
{
    public abstract class NavigationDecision : Decision
    {
        public abstract bool Decide(NavigationStateController controller);

    }
}
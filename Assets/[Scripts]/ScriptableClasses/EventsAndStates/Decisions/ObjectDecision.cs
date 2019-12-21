
namespace StateMachine
{
    public abstract class ObjectDecision : Decision
{
    public abstract bool Decide(BuildObjectStateControllerMB controller);
}
}
namespace StateMachine.Actions
{
    public abstract class ObjectAction : Action
    {
        public abstract void Act(BuildObjectStateControllerMB controller);
    }
}
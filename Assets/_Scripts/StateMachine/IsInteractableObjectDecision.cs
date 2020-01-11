using BaseLibrary.StateMachine;
using UnityEngine;


namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Object_IsInteractable", menuName = "States/Decisions/Objects/Is Interactable Decision")]

    public class IsInteractableObjectDecision : ObjectDecision
    {


        public override bool Decide(StateControllerMBBase controller)
        {
            BuildObjectStateControllerMB _controller = controller as BuildObjectStateControllerMB;
            if (_controller != null)
            {
                // IInteractable interactable = _controller.gameObject.GetComponent<IInteractable>() as IInteractable;
                /// return interactable != null;
            }
            return false;
        }
    }
}

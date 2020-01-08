using BaseLibrary.StateMachine;
using UnityEngine;

namespace StateMachine
{
    [CreateAssetMenu(fileName = "Action_Object_DecreaseParameters", menuName = "States/Actions/Objects/Decrease Parameters")]

    public class DecreaseParameterObjectAction : ObjectAction
    {
        public override void Act(StateControllerMBBase controller)
        {
            BuildObjectStateControllerMB _controller = controller as BuildObjectStateControllerMB;
            if (_controller != null)
            {
                _controller.paramValue -= _controller.paramDecreaseRate * (_controller.interval + 1);
            }
        }
    }
}

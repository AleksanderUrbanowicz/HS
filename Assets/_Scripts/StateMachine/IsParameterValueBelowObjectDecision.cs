using UnityEngine;

namespace Assets._Scripts.StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Object_IsParameterValueBelow", menuName = "States/Decisions/Objects/Is Parameter Value Below Decision")]

    public class IsParameterValueBelowObjectDecision : ObjectDecision
    {
        public float minValue;
        public override bool Decide(StateControllerMBBase controller)
        {
            BuildObjectStateControllerMB _controller = controller as BuildObjectStateControllerMB;
            if (_controller != null)
            {
                return _controller.paramValue <= minValue;
            }
            return false;
        }
    }
}
using ScriptableData;
using UnityEngine;
namespace StateMachine
{
    [CreateAssetMenu(fileName = "Decision_Debug", menuName = "States/Decisions/Debug Decision")]

    public class DebugDecision : Decision
    {
        public bool b;
        [Tooltip("Overrides B value, select none to use B")]
        public ScriptableBool scriptableBool;
        public bool B
        {
            get
            {
                if (scriptableBool != null)
                {
                    return scriptableBool.value;
                }
                else
                {

                    return b;
                }
            }
        }

        public override bool Decide(StateControllerMBBase controller)
        {
            return B;

        }
    }
}
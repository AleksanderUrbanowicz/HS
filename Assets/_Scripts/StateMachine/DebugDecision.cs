using Assets._Scripts.Data.Containers;
using UnityEngine;
namespace Assets._Scripts.StateMachine
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
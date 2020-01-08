using BaseLibrary.StateMachine;
using Data.Containers;

namespace StateMachine

{
    public class BuildObjectStateControllerMB : StateControllerMBBase
    {

        public float paramDecreaseRate;
        public float paramValue;
        // [Range(0, 20)]
        //  public new int interval = 0;


        public void Init(BuildObjectData _buildObjectData)
        {
          //  currentState = ScriptableSystemManager.Instance.gameSettings.buildObjectStartState;
         //   remainState = ScriptableSystemManager.Instance.gameSettings.remainInState;
            paramDecreaseRate = 0.01f;
            paramValue = 100.0f;
        }


    }
}
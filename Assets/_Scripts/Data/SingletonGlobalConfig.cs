using BaseLibrary.BaseAndAbstracts;
using BaseLibrary.StateMachine;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Config_Global", menuName = "Config/Singleton Global Config")]
    public class SingletonGlobalConfig : ScriptableSingleton<SingletonGlobalConfig, MonoBehaviourHookup>
    {

      //  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
      //  public static void BeforeSceneLoad() { CreateSingletonInstance(); }


        public State buildObjectStartState;
        public State remainInState;


    }
}
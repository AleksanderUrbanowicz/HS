using BaseLibrary.BaseAndAbstracts;
using BaseLibrary.DataContainers;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "Config_Gameplay", menuName = "Config/Singleton Gameplay Config")]
    public class GameplayConfig : ScriptableSingleton<GameplayConfig, MonoBehaviourHookup>
    {
        public TransformRuntimeCollection AllPluggableTransforms;

        public GameplaySettings gameplaySettings;
      //  [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
      //  public static void BeforeSceneLoad() { CreateSingletonInstance(); }

        public void Init()
        {
            // Debug.Log(GetType().Name + " Init.");

        }
    }
}

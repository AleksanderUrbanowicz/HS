using Assets._Scripts.Gameplay.MonoBehaviourHookups;
using UnityEngine;

namespace Assets._Scripts.Gameplay.Managers
{
    public class ScriptableSingleton<T> : ScriptableMonoBehaviour where T : ScriptableMonoBehaviour
    {
        private static T _instance;
        private static bool _instantiated;
        public static T Instance
        {
            get
            {
                if (_instantiated) return _instance;
                var singletonName = typeof(T).Name;

                var assets = Resources.LoadAll<T>("");
                if (assets.Length == 0)
                {
                    _instance = CreateInstance<T>();
                }
                else
                {
                    _instance = assets[0];
                }
                _instantiated = true;
                var go = new GameObject(typeof(T).Name);
                go.SetActive(false);
                MonoBehaviourHookup monoBehaviourHookup = go.AddComponent<MonoBehaviourHookup>();
                monoBehaviourHookup.Parent = _instance;
                _MonoBehaviour = monoBehaviourHookup;
                DontDestroyOnLoad(_MonoBehaviour.gameObject);
                monoBehaviourHookup.gameObject.SetActive(true); //Awake
                return _instance;
            }
        }

        protected static MonoBehaviour _MonoBehaviour;
        public static void CreateSingletonInstance() { ScriptableMonoBehaviour i = Instance; }
        private void OnDestroy() { _instantiated = false; }
    }
}
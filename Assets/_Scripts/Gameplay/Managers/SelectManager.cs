using BaseLibrary.Managers;
using Data;
using Data.Containers;
using StateMachine;
using UnityEngine;


namespace Managers
{
    [CreateAssetMenu(fileName = "SelectManager", menuName = "ScriptableSystems/Select System/Singleton Manager asset")]
    public class SelectManager : ScriptableSingleton<SelectManager>
    {
        public RaycastExecutor raycastExecutor;
        public RaycastData raycastData;
        public BoolEventListener hitMissListeners;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BeforeSceneLoad() { CreateSingletonInstance(); }

        public void Init()
        {
            Debug.Log(GetType().Name + " Init.");

            // InitRaycaster();
           // InitEventListeners();



        }

        public override void MonoBehaviourAwake()
        {
            Debug.Log(GetType().Name + " Awake.");

            Init();
        }

        public void InitEventListeners()
        {
            hitMissListeners = new BoolEventListener("SelectManagerHit", _MonoBehaviour.gameObject.transform, raycastData.hitMissEvents.scriptableEventTrue, HandleFocusHit, raycastData.hitMissEvents.scriptableEventFalse, HandleFocusMiss);

        }

        public void InitRaycaster()
        {
            raycastExecutor = _MonoBehaviour.gameObject.AddComponent<RaycastExecutor>();
            raycastExecutor.Init(raycastData);

        }


        private void HandleFocusMiss()
        {
            Debug.LogError("HandleFocusMiss");


        }

        private void HandleFocusHit()
        {
            Debug.LogError("HandleFocusHit");



        }
        /*
        * 
        * 

       private IEnumerator SimpleCoroutine()
       {
           while (true)
           {
               Debug.Log(GetType().Name + " coroutine test.");
               yield return new WaitForSeconds(3);
           }
       }
         public override void ScriptableObjectAwake()
       {
           Debug.Log(GetType().Name + " created.");
       }


       public override void MonoBehaviourAwake()
       {
           Debug.Log(GetType().Name + " Awake.");


           _MonoBehaviour.StartCoroutine(SimpleCoroutine());
       }

       public override void Update()
       {

       }


       public override void FixedUpdate()
       {

       }
       */
    }
}

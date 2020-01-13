using BaseLibrary.Managers;
using BaseLibrary.StateMachine;
using GeneralImplementations.Data;
using GeneralImplementations.Managers;
using UnityEngine;
namespace Managers
{
    [CreateAssetMenu(fileName = "Manager_Build", menuName = "Managers/ Singleton Build Manager")]
    public class SingletonBuildManager : ScriptableSingleton<SingletonBuildManager, BuildManagerMonoBehaviourHookup>
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void BeforeSceneLoad() { CreateSingletonInstance(); }
        [SerializeField]
        private BuildObjectsHelperData buildObjectsHelper;
        public DebugGizmosData gizmosData;
        public RaycastData raycastData;
        public PreviewData previewData;

        private bool isManagerActive;
        public bool logs = true;
        private BuildManagerMonoBehaviourHookup monoBehaviourHookup;

        // public PreviewBuildObject PreviewObject { get => BuildPreviewExecutor.PreviewObject;  }
        public BuildManagerMonoBehaviourHookup MonoBehaviourHookup
        {
            get
            {
                if (monoBehaviourHookup == null)
                {
                    Debug.LogError("BEFORE SingletonBuildManager.MonoBehaviourHookup == null");
                    monoBehaviourHookup = _MonoBehaviour.GetComponent<BuildManagerMonoBehaviourHookup>();
                    Debug.LogError("AFTER SingletonBuildManager.MonoBehaviourHookup :"+monoBehaviourHookup.name);
                }
                return monoBehaviourHookup;
            }
            set => monoBehaviourHookup = value;
        }
        public RaycastExecutor BuildSystemRaycast { get => MonoBehaviourHookup.BuildSystemRaycast; set => MonoBehaviourHookup.BuildSystemRaycast = value; }
        public BuildPreviewExecutor BuildPreviewExecutor
        {
            get
            {

                return MonoBehaviourHookup.BuildPreviewExecutor;
            }
            set => MonoBehaviourHookup.BuildPreviewExecutor = value;
        }

        public bool IsManagerActive
        {
            get
            {
                return isManagerActive;
            }

            set
            {

                if (value != isManagerActive)
                {
                    isManagerActive = value;
                    if (value)
                    {
                        StartBuildManager();
                    }
                    else
                    {

                        StopBuildManager();
                    }
                }

            }
        }
        public BuildObjectsHelperData BuildObjectsHelper { get => buildObjectsHelper; set => buildObjectsHelper = value; }
        public override void Update()
        {
            GetDebugInput();
        }
        public override void Start()
        {
           // Debug.LogError(" SingletonBuildManager.Start ID: " + BuildObjectsHelper.CurrentBuildObject.id);
            InitRaycaster();
            InitPreviewExecutor();
            isManagerActive = false;

        }
        public void InitRaycaster()
        {
            Debug.Log(" SingletonBuildManager.InitRaycaster " );
            MonoBehaviourHookup.BuildSystemRaycast = MonoBehaviourHookup.BuildSystemRaycast != null ? MonoBehaviourHookup.BuildSystemRaycast : monoBehaviourHookup.gameObject.AddComponent<RaycastExecutor>();
            MonoBehaviourHookup.BuildSystemRaycast.Init();
            MonoBehaviourHookup.BuildSystemRaycast.hitMissListeners = new BoolEventListener("BuildRaycast", _MonoBehaviour.transform, raycastData.hitMissEvents.scriptableEventTrue, HandleBuildHit, raycastData.hitMissEvents.scriptableEventFalse, HandleBuildMiss);

        }
        public void InitPreviewExecutor()
        {
            Debug.Log(" SingletonBuildManager.InitPreviewExecutor ");
            MonoBehaviourHookup.BuildPreviewExecutor = MonoBehaviourHookup.BuildPreviewExecutor != null ? MonoBehaviourHookup.BuildPreviewExecutor : monoBehaviourHookup.gameObject.AddComponent<BuildPreviewExecutor>();
            MonoBehaviourHookup.BuildPreviewExecutor.Init(BuildObjectsHelper.CurrentBuildObject);
            // MonoBehaviourHookup.RaycastHitInterpreter = MonoBehaviourHookup.RaycastHitInterpreter != null ? MonoBehaviourHookup.RaycastHitInterpreter : monoBehaviourHookup.gameObject.AddComponent<PreviewRaycastHitInterpreter>();
            //  MonoBehaviourHookup.RaycastHitInterpreter PreviewRaycastHitInterpreter
        }
        public void GetDebugInput()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                IsManagerActive = true;
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                IsManagerActive = false;
            }
        }
        public void StartBuildManager()

        {
            Debug.LogError("StartBuildManager");
            //BuildPreviewExecutor.TooglePreviewGameObject(true);
            //BuildObjectsHelper.CurrentBuildObjectIndex++;
            // BuildPreviewExecutor.PreviewObject.ChangePreviewObject(BuildObjectsHelper.CurrentBuildObject);
            MonoBehaviourHookup.BuildSystemRaycast.StartExecute();

        }
        void StopBuildManager()
        {
            Debug.LogError("StoptBuildManager");


            //  BuildPreviewExecutor.TooglePreviewGameObject(false);
            MonoBehaviourHookup.BuildPreviewExecutor.StopExecute();
            MonoBehaviourHookup.BuildSystemRaycast.StopExecute();

        }
        public void HandleBuildHit()
        {
            if (logs) Debug.Log("HandleBuildHit");
            // IsShowingPreview = true;
            BuildPreviewExecutor.StartExecute();

        }
        public void HandleBuildMiss()
        {
            if (logs) Debug.Log("HandleBuildMiss");
            BuildPreviewExecutor.StopExecute();
            // IsShowingPreview = false;

        }



    }
    /*
////
///
Open Build UI
Raycast layer
{
Start prev
activate 
or Create object, delete/disable former, addcollider and mesh, se
Check hit
MapToGrid
CheckAvail
SetColor
Display
Build
Next


    ******************
    * 
    * 
    * Start
    * 

}


    */
}
//////
///


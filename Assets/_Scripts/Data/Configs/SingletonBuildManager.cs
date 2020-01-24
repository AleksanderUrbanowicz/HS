using BaseLibrary.Data;
using BaseLibrary.Managers;
using BaseLibrary.StateMachine;
using Data;
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
        public BuildObjectsHelperData buildObjectsHelper;
        public DebugGizmosData gizmosData;
        public RaycastData raycastData;
        public PreviewData previewData;
        
        public new SpawnableUIData spawnableUIData;
        public bool startOnUIShow = true;
        private bool isManagerActive;
        private BuildManagerMonoBehaviourHookup monoBehaviourHookup;

        public static BuildObjectsHelperData BuildObjectsHelper { get => Instance.buildObjectsHelper; set => Instance.buildObjectsHelper = value; }
        public static DebugGizmosData GizmosData { get => Instance.gizmosData; set => Instance.gizmosData = value; }
        public static RaycastData RaycastData { get => Instance.raycastData; set => Instance.raycastData = value; }
        public static PreviewData PreviewData { get => Instance.previewData; set => Instance.previewData = value; }

        protected override SpawnableUIData SpawnableUIData { get => spawnableUIData;  }
        public static bool IsManagerActive
        {
            get
            {
                return Instance.isManagerActive;
            }

            set
            {

                if (value != Instance.isManagerActive)
                {
                    Instance.isManagerActive = value;
                    if (value)
                    {
                        Instance.StartBuildManager();
                    }
                    else
                    {

                        Instance.StopBuildManager();
                    }
                }

            }
        }

        public static BuildManagerMonoBehaviourHookup MonoBehaviourHookup
        {
            get
            {
                if (Instance.monoBehaviourHookup == null)
                {
                    Instance.monoBehaviourHookup = _MonoBehaviour.GetComponent<BuildManagerMonoBehaviourHookup>();
                }
                return Instance.monoBehaviourHookup;
            }
            set => Instance.monoBehaviourHookup = value;
        }
        public static RaycastExecutor BuildSystemRaycast { get => MonoBehaviourHookup.BuildSystemRaycast; set => MonoBehaviourHookup.BuildSystemRaycast = value; }
        public static BuildPreviewExecutor BuildPreviewExecutor
        {
            get
            {
                return MonoBehaviourHookup.BuildPreviewExecutor;
            }
            set => MonoBehaviourHookup.BuildPreviewExecutor = value;
        }

        public static PreviewHelper PreviewHelper
        {
            get
            {
                return MonoBehaviourHookup.PreviewHelper;
            }
            set => MonoBehaviourHookup.PreviewHelper = value;
        }

        public static PreviewBuildObject PreviewBuildObject
        {
            get
            {
                return MonoBehaviourHookup.PreviewHelper.PreviewBuildObject;
            }
            set => MonoBehaviourHookup.PreviewHelper.PreviewBuildObject = value;
        }


        public override void Update()
        {
            GetDebugInput();
        }
        public override void Start()
        {
            // Debug.LogError(" SingletonBuildManager.Start ID: " + BuildObjectsHelper.CurrentBuildObject.id);
            //InitRaycaster();
            //  InitPreviewExecutor();

            InitMonoBehaviours();
              isManagerActive = false;

        }

        public void InitMonoBehaviours()
        {
            MonoBehaviourHookup.BuildSystemRaycast = monoBehaviourHookup.GetComponent<RaycastExecutor>() != null ? monoBehaviourHookup.GetComponent<RaycastExecutor>() : monoBehaviourHookup.gameObject.AddComponent<RaycastExecutor>();
            MonoBehaviourHookup.BuildPreviewExecutor = monoBehaviourHookup.GetComponent<BuildPreviewExecutor>() != null ? monoBehaviourHookup.GetComponent<BuildPreviewExecutor>() : monoBehaviourHookup.gameObject.AddComponent<BuildPreviewExecutor>();

            MonoBehaviourHookup.RaycastExecutorData = monoBehaviourHookup.GetComponent<RaycastExecutorData>() != null ? monoBehaviourHookup.GetComponent<RaycastExecutorData>() : monoBehaviourHookup.gameObject.AddComponent<RaycastExecutorData>();
            MonoBehaviourHookup.PreviewHelper = monoBehaviourHookup.GetComponent<PreviewHelper>() != null ? monoBehaviourHookup.GetComponent<PreviewHelper>() : monoBehaviourHookup.gameObject.AddComponent<PreviewHelper>();
            MonoBehaviourHookup.PreviewHelper.previewSpawner = monoBehaviourHookup.GetComponent<PreviewSpawner>() != null ? monoBehaviourHookup.GetComponent<PreviewSpawner>() : monoBehaviourHookup.gameObject.AddComponent<PreviewSpawner>();
            MonoBehaviourHookup.BuildPreviewExecutor.RaycastHitInterpreter = monoBehaviourHookup.GetComponent<PreviewRaycastHitInterpreter>() != null ? monoBehaviourHookup.GetComponent<PreviewRaycastHitInterpreter>() : monoBehaviourHookup.gameObject.AddComponent<PreviewRaycastHitInterpreter>();

            MonoBehaviourHookup.EventsListenersParent = MonoBehaviourHookup.EventsListenersParent == null ? new GameObject("EventsListeners").transform : MonoBehaviourHookup.EventsListenersParent;
            MonoBehaviourHookup.EventsListenersParent.parent = MonoBehaviourHookup.transform;
            MonoBehaviourHookup.BuildSystemRaycast.hitMissListeners = new BoolEventListener("BuildRaycast", monoBehaviourHookup.EventsListenersParent.transform, RaycastData.hitMissEvents.scriptableEventTrue, HandleBuildHit, RaycastData.hitMissEvents.scriptableEventFalse, HandleBuildMiss);
        }
      
        public void GetDebugInput()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                IsManagerActive = !isManagerActive;
            }
            
           else if (Input.GetKeyDown(KeyCode.R))
            {
                if(IsManagerActive)
                {
                    MonoBehaviourHookup.PreviewHelper.PreviewBuildObject.userRotationF += MonoBehaviourHookup.PreviewHelper.PreviewBuildObject.buildObjectData.rotationStep;
                    MonoBehaviourHookup.BuildPreviewExecutor.RaycastHitInterpreter.UpdatePreviewTransform(BuildPreviewExecutor.RaycastExecutorData.lastMappedPoint);
                    Debug.Log(MonoBehaviourHookup.PreviewHelper.PreviewBuildObject.userRotationF);
                }
            }
            
            else if (  Input.GetKeyDown(KeyCode.E))
            {
                if(MonoBehaviourHookup.PreviewHelper.IsAvailable)
                {
                    MonoBehaviourHookup.PreviewHelper.previewSpawner.CreateInstance(monoBehaviourHookup.transform, PreviewBuildObject.transform.position, PreviewBuildObject.transform.rotation, PreviewBuildObject.buildObjectData);

                }
             
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                BuildObjectsHelper.CurrentBuildObjectIndex++;

            }

        }
        public void StartBuildManager()

        {
            //  Debug.Log("StartBuildManager");
            SingletonUIManager.Instance.ToggleUI(SpawnableUIData, true);
            if(startOnUIShow)
            {
            MonoBehaviourHookup.BuildSystemRaycast.StartExecute();
            }
            if (startOnUIShow)
            {
                MonoBehaviourHookup.BuildSystemRaycast.StartExecute();
            }

        }
        void StopBuildManager()
        {
            // Debug.Log("StoptBuildManager");


            //  BuildPreviewExecutor.TooglePreviewGameObject(false);
            //MonoBehaviourHookup.BuildPreviewExecutor.StopExecute();
            SingletonUIManager.Instance.ToggleUI(SpawnableUIData, false);
            
         if (startOnUIShow)
                    {
                MonoBehaviourHookup.BuildSystemRaycast.StopExecute();
            }
        }
        public void HandleBuildHit()
        {


            BuildPreviewExecutor.StartExecute();

        }
        public void HandleBuildMiss()
        {

            BuildPreviewExecutor.StopExecute();


        }



    }
}
using UnityEngine;

namespace ScriptableSystems
{
    [RequireComponent(typeof(Camera))]
    public class SelectSystemMonoBehaviour : MonoBehaviour
    {

        public Material heighlightedMaterial;
        public Material sellectedMaterial;
        public ScriptableSelectSystem scriptableSelectSystem;
        public float raycastMaxDistance;
        public BuildSystemRaycast buildSystemRaycast;
        public int raycastInterval;
        public Camera highlightCamera;
        private bool isInSelectMode;
        public string highlightedLayer;
        public string tempLayer;
        public GameObject highlightedObject;

        public ScriptableEventListener scriptableEventListenerOnHit;
        public ScriptableEventListener scriptableEventListenerOnMiss;
        public void Init(ScriptableSelectSystem _scriptableSelectSystem)
        {
            scriptableSelectSystem = _scriptableSelectSystem;

            InitRaycaster(_scriptableSelectSystem);
            InitEventListeners(_scriptableSelectSystem);
            heighlightedMaterial = _scriptableSelectSystem.heighlightedMaterial;
            sellectedMaterial = _scriptableSelectSystem.sellectedMaterial;

            raycastMaxDistance = _scriptableSelectSystem.raycastMaxDistance;
            raycastInterval = _scriptableSelectSystem.raycastInterval;
            highlightedLayer = _scriptableSelectSystem.highlightedLayer;
            InitHighlightCamera();
        }

        void Update()
        {



            if (Input.GetKeyDown(KeyCode.V))
            {
                isInSelectMode = !isInSelectMode;
                if (!isInSelectMode)
                {
                    buildSystemRaycast.StopExecute();
                }
                else
                {
                    buildSystemRaycast.StartExecute(_layersToBuildOn: scriptableSelectSystem.highlightableLayerMask);

                }

            }
        }

        public void InitEventListeners(ScriptableSelectSystem _scriptableSelectSystem)
        {
            scriptableEventListenerOnHit = new GameObject("scriptableEventListenerOnHit").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnHit.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnHit.Response = new UnityEngine.Events.UnityEvent();

            scriptableEventListenerOnMiss = new GameObject("scriptableEventListenerOnMiss").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnMiss.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnMiss.Response = new UnityEngine.Events.UnityEvent();

            scriptableEventListenerOnHit.Event = _scriptableSelectSystem.EventSelectRaycastHit;
            scriptableEventListenerOnHit.Response.AddListener(() => HandleSelectHit());
            scriptableEventListenerOnHit.Validate();

            scriptableEventListenerOnMiss.Event = _scriptableSelectSystem.EventSelectRaycastMiss;
            scriptableEventListenerOnMiss.Response.AddListener(() => HandleSelectMiss());
            scriptableEventListenerOnMiss.Validate();
        }



        public void InitRaycaster(ScriptableSelectSystem _scriptableSelectSystem)
        {
            buildSystemRaycast = new GameObject("selectSystemRaycast").AddComponent<BuildSystemRaycast>();
            buildSystemRaycast.gameObject.transform.parent = gameObject.transform;
            buildSystemRaycast.Init(_scriptableSelectSystem);

        }

        public void InitHighlightCamera()
        {
            highlightCamera = GetComponent<Camera>();
            highlightCamera.clearFlags = CameraClearFlags.Depth;
            transform.parent = buildSystemRaycast.cam.transform;
            transform.localPosition = Vector3.zero;
            highlightCamera.cullingMask = LayerMask.NameToLayer(highlightedLayer);
            highlightCamera.backgroundColor = new Color(0, 0, 0, 0);
            // highlightCamera.render =RenderTargetSetupe;

        }

        private void HandleSelectMiss()
        {
            Debug.LogError("HandleSelectMiss");
            highlightedObject.layer = LayerMask.NameToLayer(tempLayer);


        }

        private void HandleSelectHit()
        {
            Debug.LogError("HandleSelectHit");
            highlightedObject = buildSystemRaycast.raycastHit.collider.gameObject;
            tempLayer = LayerMask.LayerToName(highlightedObject.layer);
            highlightedObject.layer = LayerMask.NameToLayer(highlightedLayer);
            //highlightedObject.transform.ch


        }


    }

}
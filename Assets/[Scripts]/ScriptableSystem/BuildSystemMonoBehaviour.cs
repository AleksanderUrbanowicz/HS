using Gameplay;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//TO REIMPLEMENT

namespace ScriptableSystems
{
    public class BuildSystemMonoBehaviour : MonoBehaviour
    {
        public BuildSystemRaycast buildSystemRaycast;

        private Color availableColor = new Color(0, 1.0f, 0, 0.2f);
        private Color unavailableColor = new Color(1.0f, 0, 0, 0.2f);
        private Material previewMaterial;

        public List<BuildObjectData> buildObjectsData = new List<BuildObjectData>();
        private BuildObjectData currentBuildObject;
        public int currentBuildObjectIndex = 0;
        private Quaternion rotation;
        private Quaternion userRotation;

        public float userRotationF;
        private GameObject currentPreviewGameObject;
        private BuildObjectData currentPreviewObject;
        public Transform currentPreview;
        private Vector3 currentPosition = Vector3.zero;
        private BoxCollider previewCollider;
        private MeshRenderer previewRenderer;

        public Transform cam;
        public Transform buildObjectsParent;
        private RaycastHit raycastHit;

        public int cash;

        public float offset = 1.0f;
        public float gridSize = 1.0f;
        public float previewSnapFactor = 1.0f;
        public float mainAxisLength = 15.0f;

        private bool canBeBuild;
        private bool isBuilding;
        private bool isShowingPreview;

        public Vector3 collisionCenterDebug;
        public Vector3 collisionNormal;
        public Vector3 cornerAxisVector = new Vector3(-5, 0, -5);
        public int counter;
        public ScriptableBuildSystem scriptableBuildSystem;

        public ScriptableEventListener scriptableEventListenerOnHit;
        public ScriptableEventListener scriptableEventListenerOnMiss;
        public void Init(ScriptableBuildSystem _scriptableBuildSystem)
        {
            scriptableBuildSystem = _scriptableBuildSystem;

            InitRaycaster(_scriptableBuildSystem);
            InitEventListeners(_scriptableBuildSystem);

            availableColor = _scriptableBuildSystem.availableColor;
            unavailableColor = _scriptableBuildSystem.unavailableColor;
            previewMaterial = _scriptableBuildSystem.previewMaterial;
            buildObjectsData = _scriptableBuildSystem.buildObjects.items;
            previewSnapFactor = scriptableBuildSystem.previewSnapFactor;
            offset = scriptableBuildSystem.offset;
            gridSize = scriptableBuildSystem.gridSize;

        }

        public void InitEventListeners(ScriptableBuildSystem _scriptableBuildSystem)
        {
            scriptableEventListenerOnHit = new GameObject("scriptableEventListenerOnHit").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnHit.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnHit.Response = new UnityEngine.Events.UnityEvent();

            scriptableEventListenerOnMiss = new GameObject("scriptableEventListenerOnMiss").AddComponent<ScriptableEventListener>();
            scriptableEventListenerOnMiss.gameObject.transform.parent = gameObject.transform;
            scriptableEventListenerOnMiss.Response = new UnityEngine.Events.UnityEvent();

            scriptableEventListenerOnHit.Event = _scriptableBuildSystem.EventPreviewRaycastHit;
            scriptableEventListenerOnHit.Response.AddListener(() => HandlePreviewHit());
            scriptableEventListenerOnHit.Validate();

            scriptableEventListenerOnMiss.Event = _scriptableBuildSystem.EventPreviewRaycastMiss;
            scriptableEventListenerOnMiss.Response.AddListener(() => HandlePreviewMiss());
            scriptableEventListenerOnMiss.Validate();
        }

        public void InitRaycaster(ScriptableBuildSystem _scriptableBuildSystem)
        {
            buildSystemRaycast = new GameObject("buildSystemRaycast").AddComponent<BuildSystemRaycast>();
            buildSystemRaycast.gameObject.transform.parent = gameObject.transform;
            buildSystemRaycast.Init(_scriptableBuildSystem);

        }
        private void Start()
        {
            if (buildObjectsParent == null)
            {
                buildObjectsParent = new GameObject("BuildObjects").transform;
            }
            GameManager.instance.buildSystemMonoBehaviour = this;

        }

        void Update()
        {


            if (isBuilding)
            {
                if (Input.GetKeyDown(KeyCode.N))
                {
                    currentBuildObjectIndex++;
                    CancelPreview();
                    CustomStart();
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    RotatePreview(currentPreviewObject);
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    isBuilding = !isBuilding;
                    CancelPreview();
                }

                if (isShowingPreview)
                {
                    ShowPreview();
                    if (canBeBuild && Input.GetKeyDown(KeyCode.E))
                    {

                        BuildPreviewObject();
                        CustomStart();
                    }

                }

            }
            else
            {

                if (Input.GetKeyDown(KeyCode.B))
                {
                    isBuilding = !isBuilding;


                    CustomStart();


                }


            }



        }

        private void CustomStart()
        {
            currentBuildObjectIndex = currentBuildObjectIndex % buildObjectsData.Count;
            currentBuildObject = buildObjectsData[currentBuildObjectIndex];
            CancelPreview();
            InstantiatePreview();

            StartRaycastPreview();


        }

        public void InstantiatePreview()
        {
            Destroy(currentPreviewGameObject);
            rotation = Quaternion.identity;
            currentPreviewGameObject = Instantiate(currentBuildObject.objectPrefab, currentPosition, rotation);
            currentPreviewGameObject.name = "PreviewPrefab";
            currentPreviewObject = currentBuildObject;
            currentPreviewGameObject.transform.localPosition += currentBuildObject.offset;

            currentPreview = currentPreviewGameObject.transform;
            // AddPreviewCollider(currentPreviewGameObject, currentPreviewObject);
            AddPreviewMesh(currentPreviewGameObject, currentPreviewObject);
        }


        public void BuildPreviewObject()
        {

            //rotation = Quaternion.identity;
            GameManager.instance.cash -= currentBuildObject.cost;
            GameObject go = Instantiate(currentBuildObject.objectPrefab, currentPosition, rotation);
            go.name = currentBuildObject.id;
            go.layer = LayerMask.NameToLayer(scriptableBuildSystem.buildObjectLayerString);
            go.tag = scriptableBuildSystem.buildObjectLayerString;
            go.transform.parent = buildObjectsParent;
            AddPreviewCollider(go, currentPreviewObject);
        }


        public void StartRaycastPreview()
        {

            buildSystemRaycast.StartExecute(currentPreviewObject.layersToBuildOn);

        }
        public void CancelPreview()
        {
            if (scriptableBuildSystem.logs) Debug.Log("CancelPreview");
            if (currentPreviewGameObject != null)
            {
                Destroy(currentPreviewGameObject);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            buildSystemRaycast.StopExecute();

        }

        public void HandlePreviewHit()
        {
            if (scriptableBuildSystem.logs) Debug.Log("HandlePreviewHit");
            isShowingPreview = true;

        }
        public void HandlePreviewMiss()
        {
            if (scriptableBuildSystem.logs) Debug.Log("HandlePreviewMiss");

            isShowingPreview = false;

        }

        public void ShowPreview()
        {
            bool b = currentPreviewObject == null;
            b = b || raycastHit.point == buildSystemRaycast.raycastHit.point;
            if (scriptableBuildSystem.logs) Debug.Log("ShowPreview");
            if (b)
            {

                if (scriptableBuildSystem.logs) Debug.LogError("ShowPreview: Hit.point have not changed");
                return;
            }
            raycastHit = buildSystemRaycast.raycastHit;

            Vector3 point = raycastHit.point;
            Vector3 normal = raycastHit.normal;


            //  if (currentPreviewObject == null)
            //{
            //   return;

            //}

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ShowPreview( point: " + point + "normal: " + normal);

            float distance = Vector3.Distance(currentPosition, point);
            sb.AppendLine("Distance: " + distance);
            if (distance > (previewSnapFactor * gridSize))
            {

                CalculatePreview(point, normal);
                CheckObject();
            }



        }

        public void CalculatePreview(Vector3 _point, Vector3 _normal)
        {
            collisionNormal = _normal;

            rotation = Quaternion.FromToRotation(currentPreviewObject.orientationVector, collisionNormal);
            rotation *= Quaternion.Euler(currentPreviewObject.orientationVector * userRotationF);

            currentPosition = _point;
            currentPosition -= Vector3.one * offset;
            currentPosition /= gridSize;
            currentPosition = new Vector3(Mathf.Round(currentPosition.x), Mathf.Round(currentPosition.y), Mathf.Round(currentPosition.z));
            currentPosition *= gridSize;
            currentPosition += Vector3.one * offset;

            currentPreview.position = currentPosition;

            currentPreview.rotation = rotation;

        }

        public bool CheckAvailability()
        {
            if (scriptableBuildSystem.logs) Debug.Log("CheckAvailability");
            collisionCenterDebug = currentPreview.position + previewCollider.center;
            Vector3 halfEx = previewCollider.bounds.extents * currentPreviewObject.collsionBoundsFraction;
            // halfEx.x *= previewCollider.transform.localScale.x;
            // halfEx.y *= previewCollider.transform.localScale.y;
            //  halfEx.z *= previewCollider.transform.localScale.z;

            Debug.Log("halfEx:" + halfEx);
            Debug.Log("previewCollider.bounds.extents:" + previewCollider.bounds.extents);

            Collider[] hitColliders = Physics.OverlapBox(currentPreview.position + previewCollider.center, halfEx, previewCollider.transform.rotation, currentPreviewObject.obstacleLayers);

            // Collider[] hitColliders = Physics.OverlapBox(currentPreview.position + previewCollider.center, previewCollider.bounds.extents * currentPreviewObject.collsionBoundsFraction, Quaternion.identity, currentPreviewObject.obstacleLayers);
            int i = 0;


            while (i < hitColliders.Length)
            {
                Collider hitCollider = hitColliders[i];

                if (hitCollider.gameObject != this.gameObject && hitCollider.gameObject.layer != currentPreviewObject.layersToBuildOn)
                {

                    return false;
                }

                i++;
            }


            return true;

        }

        public void CheckObject()
        {



            if (CheckAvailability() == true && GameManager.instance.cash >= currentBuildObject.cost)
            {
                SetPreviewColor(availableColor);
                canBeBuild = true;
            }
            else
            {
                canBeBuild = false;
                SetPreviewColor(unavailableColor);

            }

        }

        public void SetPreviewColor(Color c)
        {
            previewRenderer.material.color = c;
        }


        private void AddPreviewCollider(GameObject _sceneGO, BuildObjectData _currentPreviewObject)
        {

            BoxCollider boxCollider = _sceneGO.AddComponent<BoxCollider>();
            boxCollider.isTrigger = true;
            if (_currentPreviewObject.objectOrientation == ObjectOrientation.WALL)
            {
                boxCollider.center = new Vector3(0, 0, -(_currentPreviewObject.gridSize.z / 2.0f) + _currentPreviewObject.actualSize.z);


            }
            else if (_currentPreviewObject.objectOrientation == ObjectOrientation.FLOOR)
            {

                boxCollider.center = new Vector3(0, _currentPreviewObject.gridSize.y / 2.0f, 0);

            }
            boxCollider.size = _currentPreviewObject.gridSize;
            previewCollider = boxCollider;

        }

        private void AddPreviewMesh(GameObject _sceneGO, BuildObjectData _currentPreviewObject)
        {

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);


            cube.transform.SetParent(_sceneGO.transform);

            cube.transform.localScale = new Vector3(_currentPreviewObject.gridSize.x, _currentPreviewObject.gridSize.y, _currentPreviewObject.gridSize.z);
            if (_currentPreviewObject.objectOrientation == ObjectOrientation.WALL)
            {
                cube.transform.localPosition = new Vector3(0, 0, -(_currentPreviewObject.gridSize.z / 2.0f) + _currentPreviewObject.actualSize.z);


            }
            else if (_currentPreviewObject.objectOrientation == ObjectOrientation.FLOOR)
            {

                cube.transform.localPosition = new Vector3(0, (_currentPreviewObject.actualSize.y) / 2.0f, 0) + _currentPreviewObject.offset;

            }
            previewRenderer = cube.gameObject.GetComponent<MeshRenderer>();
            previewRenderer.material = previewMaterial;
            BoxCollider box = cube.GetComponent<BoxCollider>();
            box.isTrigger = true;
            previewCollider = box;
        }

        private void RotatePreview(BuildObjectData _currentPreviewObject)
        {
            float newAngle = ((rotation.eulerAngles.x * _currentPreviewObject.orientationVector.x * collisionNormal.x)
                + (rotation.eulerAngles.y * _currentPreviewObject.orientationVector.y * collisionNormal.y)
                + (rotation.eulerAngles.z * _currentPreviewObject.orientationVector.z * collisionNormal.z)
                + _currentPreviewObject.rotationStep);

            float newAngleAlt = ((rotation.eulerAngles.x * _currentPreviewObject.orientationVector.x)
               + (rotation.eulerAngles.y * _currentPreviewObject.orientationVector.y)
               + (rotation.eulerAngles.z * _currentPreviewObject.orientationVector.z)
               + _currentPreviewObject.rotationStep);
            Vector3 orientationVectorMultiplied = new Vector3(_currentPreviewObject.orientationVector.x * collisionNormal.x,
                _currentPreviewObject.orientationVector.y * collisionNormal.y,
                 _currentPreviewObject.orientationVector.z * collisionNormal.z);

            userRotationF = newAngle;
            Debug.Log("userRotation: " + userRotationF);
            CalculatePreview(raycastHit.point, raycastHit.normal);
            CheckObject();

        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(currentPosition, 0.04f);
            Gizmos.DrawSphere(raycastHit.point, 0.02f);

            Gizmos.DrawLine(raycastHit.point, raycastHit.point + raycastHit.normal);
            Gizmos.color = Color.red;
            Gizmos.DrawLine(cornerAxisVector, cornerAxisVector + Vector3.right * mainAxisLength);

            bool b = currentPreview != null;
            //  if (currentPreview != null)
            if (b)
            {

                Gizmos.DrawLine(currentPreview.transform.position, currentPreview.transform.position + Vector3.right * 1.5f);



                Gizmos.color = Color.green;
                Gizmos.DrawLine(cornerAxisVector, cornerAxisVector + Vector3.up * mainAxisLength);


                Gizmos.DrawLine(currentPreview.transform.position, currentPreview.transform.position + Vector3.up * 1.5f);

                Gizmos.color = Color.blue;



                Gizmos.DrawLine(currentPreview.transform.position, currentPreview.transform.position + Vector3.forward * 1.5f);
            }
            Gizmos.DrawLine(cornerAxisVector, cornerAxisVector + Vector3.forward * mainAxisLength);
            b = b && previewCollider != null;
            // if (currentPreview != null && previewCollider!=null)
            if (b)
            {
                Vector3 halfEx = previewCollider.bounds.extents;
                halfEx.x *= previewCollider.transform.localScale.x;
                halfEx.y *= previewCollider.transform.localScale.y;
                halfEx.z *= previewCollider.transform.localScale.z;
                Gizmos.matrix = Matrix4x4.TRS(previewCollider.transform.position + previewCollider.center, previewCollider.transform.rotation, previewCollider.transform.localScale);
                Gizmos.color = Color.magenta;

                // Gizmos.DrawCube(Vector3.zero, Vector3.one);
            }

        }
    }
}
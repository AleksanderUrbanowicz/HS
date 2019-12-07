using UnityEngine;

namespace ScriptableSystems
{
    public class BuildSystemRaycast : MonoBehaviour
    {

        public Transform cam;

        public RaycastHit raycastHit;
        public bool isRaycasting;
        public bool stopAfterHit;
        public int raycastInterval;
        public int counter = 0;
        public float raycastMaxDistance = 10.0f;


        public Vector3 collisionNormal;
        public LayerMask layersToCheck;
        public bool output;
        public ScriptableEvent ScriptableEventHit;
        public ScriptableEvent ScriptableEventMiss;


        public void Init(ScriptableBuildSystem scriptableBuildSystem)
        {
            if (cam == null)
            {

                cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

            }
            layersToCheck = scriptableBuildSystem.buildObjects.items[0].layersToBuildOn;
            ScriptableEventHit = scriptableBuildSystem.EventPreviewRaycastHit;
            ScriptableEventMiss = scriptableBuildSystem.EventPreviewRaycastMiss;
            raycastInterval = scriptableBuildSystem.raycastInterval;
            raycastMaxDistance = scriptableBuildSystem.raycastMaxDistance;

        }

        public void Init(ScriptableSelectSystem scriptableSelectSystem)
        {
            if (cam == null)
            {

                cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

            }
            layersToCheck = scriptableSelectSystem.highlightableLayerMask;
            ScriptableEventHit = scriptableSelectSystem.EventSelectRaycastHit;
            ScriptableEventMiss = scriptableSelectSystem.EventSelectRaycastMiss;
            raycastInterval = scriptableSelectSystem.raycastInterval;
            raycastMaxDistance = scriptableSelectSystem.raycastMaxDistance;
            stopAfterHit = true;
        }

        public void Update()
        {
            if (isRaycasting)
            {
                counter++;
                if (counter >= raycastInterval)
                {

                    if (output != Physics.Raycast(cam.position, cam.forward, out raycastHit, raycastMaxDistance, layersToCheck))
                    {
                        output = !output;
                        if (output)
                        {
                            if (stopAfterHit)
                            {
                                StopExecute();

                            }
                            ScriptableEventHit.Raise();
                        }
                        else { ScriptableEventMiss.Raise(); }


                    }


                    counter = 0;
                }

            }
        }

        public void StartExecute(LayerMask _layersToBuildOn)
        {
            layersToCheck = _layersToBuildOn;
            isRaycasting = true;
        }
        public void StopExecute()
        {
            isRaycasting = false;
        }

    }
}
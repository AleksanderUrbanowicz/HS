using StateMachine;
using UnityEngine;

namespace Managers
{
    public class BuildSystemRaycast : MonoBehaviour
    {

        public Transform cam;

        public RaycastHit raycastHit;
        private bool isRaycasting;
        private bool stopAfterHit;
        private int raycastInterval;
        private int counter = 0;
        private float raycastMaxDistance = 10.0f;


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
            if (scriptableBuildSystem.buildObjects.items == null || scriptableBuildSystem.buildObjects.items.Count == 0)
            {
                layersToCheck = scriptableBuildSystem.defaultLayerToBuildOn;

            }
            else
            {
                layersToCheck = scriptableBuildSystem.buildObjects.items[0].layersToBuildOn;


            }
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
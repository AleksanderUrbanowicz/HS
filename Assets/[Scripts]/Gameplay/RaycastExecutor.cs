using UnityEngine;

namespace ScriptableSystems
{
    public class RaycastExecutor : MonoBehaviour
    {

        public Transform target;
        public float raycastMaxDistance = 10.0f;
        public LayerMask layers;

        public RaycastHit raycastHit;
        public bool output;

        public bool isRaycasting;
        public int raycastInterval;
        public int counter = 0;

        public ScriptableEvent ScriptableEventHit;
        public ScriptableEvent ScriptableEventMiss;

        public void Init()
        {
            target = GameObject.FindGameObjectWithTag("MainCamera").transform;

        }

        public void Init(ScriptableBuildSystem scriptableBuildSystem)
        {
            layers = scriptableBuildSystem.buildObjects.items[0].layersToBuildOn;
            ScriptableEventHit = scriptableBuildSystem.EventPreviewRaycastHit;
            ScriptableEventMiss = scriptableBuildSystem.EventPreviewRaycastMiss;
            raycastInterval = scriptableBuildSystem.raycastInterval;
            raycastMaxDistance = scriptableBuildSystem.raycastMaxDistance;

        }
        public void Update()
        {
            if (isRaycasting)
            {
                counter++;
                if (counter >= raycastInterval)
                {

                    if (output != Physics.Raycast(target.position, target.forward, out raycastHit, raycastMaxDistance, layers))
                    {
                        output = !output;
                        if (output)
                        {
                            ScriptableEventHit.Raise();
                        }
                        else { ScriptableEventMiss.Raise(); }


                    }


                    counter = 0;
                }

            }
        }
    }
}
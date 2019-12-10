using UnityEngine;

namespace ScriptableSystems
{
    [CreateAssetMenu(fileName = "SelectSystem", menuName = "ScriptableSystems/Select System/System Asset")]

    public class ScriptableSelectSystem : ScriptableSystem
    {
        public Material heighlightedMaterial;
        public Material sellectedMaterial;
        public LayerMask highlightableLayerMask;

        public string highlightedLayer;
        public float raycastMaxDistance = 12.0f;

        public int raycastInterval = 1;

        public ScriptableEvent EventSelectRaycastHit;
        public ScriptableEvent EventSelectRaycastMiss;
        public override void Initialize(GameObject obj)
        {

            obj.name = id;
            SelectSystemMonoBehaviour selectSystemMonoBehaviour = obj.AddComponent<SelectSystemMonoBehaviour>();
            if (selectSystemMonoBehaviour != null)
            {

                selectSystemMonoBehaviour.Init(this);
            }

            Debug.Log("override ScriptableSelectSystem.Initialize():" + obj.name);


        }
    }

}
using Assets._Scripts.Data.Configs;
using Assets._Scripts.Data.Containers;
using UnityEngine;

namespace Assets._Scripts.Gameplay.MonoBehaviourHookups
{
    public class PluggableMonoBehaviour : MonoBehaviour
    {
        public PluggableParams totalParams = new PluggableParams();

        public void Awake()
        {
            //    Debug.Log("Awake:" + name);
            Config.RegisterPluggable(this);
        }

        public void OnDestroy()
        {
            //   Debug.Log("OnDestroy:" + name );
            Config.UnregisterPluggable(this);
        }

    }




}

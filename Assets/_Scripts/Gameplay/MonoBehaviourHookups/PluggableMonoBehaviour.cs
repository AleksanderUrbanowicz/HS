using Data;

using UnityEngine;

namespace Managers
{
    public class PluggableMonoBehaviour : MonoBehaviour
    {
        public PluggableParams totalParams = new PluggableParams();

        public void Awake()
        {
            //    Debug.Log("Awake:" + name);
            //  Config.RegisterPluggable(this);
        }

        public void OnDestroy()
        {
            //   Debug.Log("OnDestroy:" + name );
            //  Config.UnregisterPluggable(this);
        }

    }




}

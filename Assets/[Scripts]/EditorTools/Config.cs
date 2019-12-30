using ScriptableData;
using Managers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorTools
{
    public static class Config
    {
        
        public static Dictionary<string, List<Transform>> interactableTransforms = new Dictionary<string, List<Transform>>();
        static GlobalConfig globalConfig;
        public static GlobalConfig GlobalConfig
        {
            get
            {
                if(globalConfig==null)
                {

                    globalConfig= ScriptableSystemManager.Instance.gameSettings.globalConfig;
                }



                return globalConfig;
            }
        }

      


       

        public static List<PluggableMonoBehaviour> GetAllPluggableActives()
        {
            return GlobalConfig.AllActiveInteractables.Items;
        }

        



        public static void RegisterPluggable(PluggableMonoBehaviour pluggableMonoBehaviour)
        {
           // ScriptableSystemManager.Instance.gameSettings.globalConfig.AllPluggables.Add(pluggableMonoBehaviour);
            GlobalConfig.AllPluggables.Add(pluggableMonoBehaviour);
            GlobalConfig.AllPluggableTransforms.Add(pluggableMonoBehaviour.transform);
            PluggableParams interactable = pluggableMonoBehaviour.totalParams.GetInteractableParams();
          
            if (interactable.parameters.Count > 0)
            {

                GlobalConfig.AllActiveInteractables.Add(pluggableMonoBehaviour);

            }

        }
        public static void UnregisterPluggable(PluggableMonoBehaviour pluggableMonoBehaviour)
        {
            
                GlobalConfig.AllPluggables.Remove(pluggableMonoBehaviour);
            GlobalConfig.AllPluggableTransforms.Remove(pluggableMonoBehaviour.transform);


            GlobalConfig.AllActiveInteractables.Remove(pluggableMonoBehaviour);
            


            
            


        }
    }
}


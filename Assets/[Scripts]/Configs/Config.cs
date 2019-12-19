using ScriptableSystems;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorTools
{
    public static class Config
    {

        public static Dictionary<string, List<Transform>> passiveInteractableTransforms = new Dictionary<string, List<Transform>>();
        public static GlobalConfig GlobalConfig
        {
            get
            {
#if UNITY_EDITOR

                return EditorStaticTools.GetFirstInstance<GlobalConfig>();
#endif

                return ScriptableSystemManager.Instance.gameSettings.globalConfig;
            }
        }

        public static List<PluggableMonoBehaviour> GetAllPassivesPluggable()
        {

            return GlobalConfig.AllPasiveInteractables.Items;

        }


        public static List<Transform> GetPassiveInteractables(string id)
        {
            if(passiveInteractableTransforms!=null && passiveInteractableTransforms.Count>0)
            {
               if( passiveInteractableTransforms.ContainsKey(id))
                {

                    return passiveInteractableTransforms[id];
                }
               else
                {

                    
                }

            }
            Debug.LogWarning("GetPassiveInteractables( " + id + ") No Transforms");
            return null;

        }

        public static void RegisterPassiveInteractable(string id, Transform t)
        {
            if (passiveInteractableTransforms == null)
            {
                passiveInteractableTransforms = new Dictionary<string, List<Transform>>();
            }
            
                if (passiveInteractableTransforms.ContainsKey(id))
                {
                    if(!passiveInteractableTransforms[id].Contains(t))
                    {
                        passiveInteractableTransforms[id].Add(t);

                    }
                     
                }
                else
                {
                    passiveInteractableTransforms.Add(id, new List<Transform>(){t});

                }

       

        }

        public static List<PluggableMonoBehaviour> GetAllPluggableActives()
        {
            return GlobalConfig.AllActiveInteractables.Items;
        }

        public static PluggableMonoBehaviour GetAllPluggableInteractable()
        {

            PluggableMonoBehaviour allInteractable = new PluggableMonoBehaviour();
            foreach (var pb in from PluggableMonoBehaviour mb in GlobalConfig.AllActiveInteractables.Items
                               from ParameterBase pb in mb.totalParams.activeParameters
                               select pb)
            {
                allInteractable.totalParams.AddPassive(pb);
            }

            foreach (var pb in from PluggableMonoBehaviour mb in GlobalConfig.AllPasiveInteractables.Items
                               from ParameterBase pb in mb.totalParams.passiveParameters
                               select pb)
            {
                allInteractable.totalParams.AddPassive(pb);
            }

            return allInteractable;

        }

        public static PluggableParams GetMatchingInteractables(PluggableParams _pluggableParams)
        {

            PluggableParams matchingInteractables = new PluggableParams();
           
            return matchingInteractables;

        }


        public static void RegisterPluggable(PluggableMonoBehaviour pluggableMonoBehaviour)
        {
            GlobalConfig.AllPluggables.Add(pluggableMonoBehaviour);
            GlobalConfig.AllPluggableTransforms.Add(pluggableMonoBehaviour.transform);
            PluggableParams interactable = pluggableMonoBehaviour.totalParams.GetInteractableParams();
            if (interactable.passiveParameters.Count > 0)
            {

                GlobalConfig.AllPasiveInteractables.Add(pluggableMonoBehaviour);


            }
            if (interactable.activeParameters.Count > 0)
            {

                GlobalConfig.AllActiveInteractables.Add(pluggableMonoBehaviour);

            }

        }
        public static void UnregisterPluggable(PluggableMonoBehaviour pluggableMonoBehaviour)
        {
            if (GlobalConfig.AllPluggables.Items.Contains(pluggableMonoBehaviour))
            {
                GlobalConfig.AllPluggables.Remove(pluggableMonoBehaviour);
            }
            if (GlobalConfig.AllActiveInteractables.Items.Contains(pluggableMonoBehaviour))
            {
                GlobalConfig.AllActiveInteractables.Remove(pluggableMonoBehaviour);
            }


            if (GlobalConfig.AllPasiveInteractables.Items.Contains(pluggableMonoBehaviour))
            {
                GlobalConfig.AllPasiveInteractables.Remove(pluggableMonoBehaviour);
            }


        }
    }
}


using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace EditorTools
{
    public class ConfigSelectorAttribute : PropertyAttribute
    {
        public  string configKey;
        public string paramsSetKey;
        public ConfigBase config;
        public string[] parameters;

        public delegate string[] GetStringList();
        public string[] Elements
        {
            get
            {
                if (parameters != null)
                {
                    return parameters;
                }

                UpdateParameters();
                return parameters;
            }
        }

        protected  void UpdateParameters()
        {
            
#if UNITY_EDITOR
   if (config == null)
   {
                //configBase = EditorStaticTools.GetFirstInstance<Definitions>();
                if(string.IsNullOrEmpty(configKey))
                {
                    config = EditorStaticTools.GetFirstInstance<GlobalConfig>();

                }
                else
                { 
                ConfigBase[] configs = EditorStaticTools.GetAllInstances<ConfigBase>();
                    if (configs != null && configs.Length > 0)
                    {
                        for (int i = 0; i < configs.Length; i++)
                        {
                            if (configKey == configs[i].Key)
                            {
                                config = configs[i];

                            }

                        }


                    }
                }
                
            }

#endif
   
   if (config != null)
   {

                parameters = config.selectorParameters.FirstOrDefault(x => x.id == paramsSetKey).parameters.ToArray() ;

   }
   
        }
    }
}
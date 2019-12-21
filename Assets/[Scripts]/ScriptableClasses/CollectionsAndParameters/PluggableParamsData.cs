using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorTools
{
    [CreateAssetMenu(fileName = "PluggableParams", menuName = "Characters/PluggableParams")]
    public class PluggableParamsData : ScriptableObject
    {
        
        public List<ParameterBase> activeParameters = new List<ParameterBase>();
       

      

    }

    [Serializable]
    public class PluggableDynamicParams
    {

        public List<DynamicParameter> activeParameters = new List<DynamicParameter>();
      

        public PluggableDynamicParams(List<DynamicParameter> actives)
        {
            activeParameters = actives;
            

        }

        public PluggableDynamicParams()
        {


        }

        public PluggableParams ToPluggableParams()
        {
            PluggableParams parameters = new PluggableParams();
            foreach (DynamicParameter par in activeParameters)
            {
                parameters.activeParameters.Add(par as ParameterBase);

            }
         
            
            return parameters;
        }

        public PluggableDynamicParams GetInteractableParams()
        {
            PluggableDynamicParams par = new PluggableDynamicParams();
            foreach (DynamicParameter parActive in activeParameters)
            {
                if (Config.GlobalConfig.interactionParameters.Contains(parActive.id))
                {
                    par.activeParameters.Add(new DynamicParameter(parActive.id, parActive.value, parActive.changeRate));

                }

            }

          
            return par;
        }
    }
    [Serializable]
    public class PluggableParams
    {

        public List<ParameterBase> activeParameters = new List<ParameterBase>();

        public PluggableParams(List<ParameterBase> actives)
        {
            activeParameters = actives;

        }


        public PluggableParams()
        {


        }

       


        public int GetIndexOfActive(string _id)
        {
            //int i = -1;
            
            ParameterBase par = activeParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                int i = activeParameters.IndexOf(par);

            }

            return -1;

        }

        

        public PluggableParams GetParams(List<string> _ids)
        {
            PluggableParams selected = new PluggableParams();
            int index;
            foreach (string s in _ids)
            {
                index = GetIndexOfActive(s);
                if (index != -1)
                {

                    selected.activeParameters.Add(new ParameterBase(activeParameters[index].id, activeParameters[index].value));
                }
           
            }
            return selected;
        }

        public PluggableParams GetInteractableParams()
        {
            PluggableParams par = new PluggableParams();
            foreach (ParameterBase parActive in activeParameters)
            {
                if (Config.GlobalConfig.interactionParameters.Contains(parActive.id))
                {
                    par.activeParameters.Add(new ParameterBase(parActive.id, parActive.value));

                }

            }
            return par;
        }

        

   

        

        public void AddActive(ParameterBase parameterBase)
        {
            foreach (ParameterBase par in activeParameters)
            {
                if (par.id == parameterBase.id)
                {
                    par.value += parameterBase.value;

                }


            }

        }

        public ParameterBase GetActive(string _id)
        {
            foreach (ParameterBase par in activeParameters)
            {
                if (par.id == _id)
                {
                    return par;

                }

            }
            return null;

        }
    }
}
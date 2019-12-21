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
        public List<ParameterBase> passiveParameters = new List<ParameterBase>();

      

    }

    [Serializable]
    public class PluggableDynamicParams
    {

        public List<DynamicParameter> activeParameters = new List<DynamicParameter>();
        public List<DynamicParameter> passiveParameters = new List<DynamicParameter>();

        public PluggableDynamicParams(List<DynamicParameter> actives, List<DynamicParameter> passives)
        {
            activeParameters = actives;
            passiveParameters = passives;

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
            foreach (DynamicParameter par in passiveParameters)
            {
                parameters.passiveParameters.Add(par as ParameterBase);

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

            foreach (DynamicParameter parPassive in passiveParameters)
            {
                if (Config.GlobalConfig.interactionParameters.Contains(parPassive.id))
                {
                    par.passiveParameters.Add(new DynamicParameter(parPassive.id, parPassive.value, parPassive.changeRate));

                }

            }
            return par;
        }
    }
    [Serializable]
    public class PluggableParams
    {

        public List<ParameterBase> activeParameters = new List<ParameterBase>();
        public List<ParameterBase> passiveParameters = new List<ParameterBase>();

        public PluggableParams(List<ParameterBase> actives, List<ParameterBase> passives)
        {
            activeParameters = actives;
            passiveParameters = passives;

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

        public int GetIndexOfPassive(string _id)
        {
            //int i = -1;
            ParameterBase par = passiveParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
               int i = passiveParameters.IndexOf(par);

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
                index = GetIndexOfPassive(s);
                if (index != -1)
                {

                    selected.passiveParameters.Add(new ParameterBase(passiveParameters[index].id, passiveParameters[index].value));
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

        public bool CheckInteraction(PluggableParams passiveObject)
        {
            for (int i = 0; i < activeParameters.Count; i++)
            {
                ParameterBase par = activeParameters[i];
                for (int j = 0; j < passiveObject.passiveParameters.Count; j++)
                {
                    ParameterBase pas = passiveObject.passiveParameters[j];
                    if (pas.id == par.id)
                    {

                        return true;
                    }
                }


            }
            return false;
        }

        public void AddPassive(ParameterBase parameterBase)
        {
            foreach (ParameterBase par in passiveParameters)
            {
                if (par.id == parameterBase.id)
                {
                    par.value += parameterBase.value;

                }


            }

        }

        public ParameterBase GetPassive(string _id)
        {
            foreach (ParameterBase par in passiveParameters)
            {
                if (par.id == _id)
                {
                    return par;

                }

            }
            return null;

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
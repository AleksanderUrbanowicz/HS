﻿using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EditorTools
{
    [CreateAssetMenu(fileName = "PluggableParams", menuName = "Characters/PluggableParams")]
    public class PluggableParamsData : ScriptableObject
    {
        // public PluggableParams pluggableParams;

        public List<ParameterBase> dynamicParameters = new List<ParameterBase>();
        public List<ParameterBase> staticParameters = new List<ParameterBase>();

        public int GetIndexOfDynamic(string _id)
        {
            int i = -1;
            // dynamicParameters.IndexOf
            ParameterBase par = dynamicParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                i = dynamicParameters.IndexOf(par);

            }

            return i;

        }

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
            List<ParameterBase> actives=new List<ParameterBase>();
            List<ParameterBase> passives = new List<ParameterBase>(); 
            foreach(DynamicParameter par in activeParameters)
            {
                actives.Add(par.ToParameterBase());

            }
            foreach (DynamicParameter par in passiveParameters)
            {
                passives.Add(par.ToParameterBase());

            }
            PluggableParams parameters = new PluggableParams(actives, passives);
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

        public Vector3 GetDebugSum()
        {
            float sumX = 0;
            float sumY = 0;
            foreach (ParameterBase param in activeParameters)
            {
                sumX += param.value;

            }
            foreach (ParameterBase param in passiveParameters)
            {
                sumY += param.value;

            }
            return new Vector3(sumX, 0, sumY);
        }


        public int GetIndexOfDynamic(string _id)
        {
            int i = -1;
            // dynamicParameters.IndexOf
            ParameterBase par = activeParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                i = activeParameters.IndexOf(par);

            }

            return i;

        }

        public int GetIndexOfStatic(string _id)
        {
            int i = -1;
            ParameterBase par = passiveParameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                i = passiveParameters.IndexOf(par);

            }

            return i;

        }

        public PluggableParams GetParams(List<string> _ids)
        {
            PluggableParams selected = new PluggableParams();
            int index;
            foreach (string s in _ids)
            {
                index = GetIndexOfDynamic(s);
                if (index != -1)
                {

                    selected.activeParameters.Add(new ParameterBase(activeParameters[index].id, activeParameters[index].value));
                }
                index = GetIndexOfStatic(s);
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
            foreach (ParameterBase par in activeParameters)
            {
                foreach (ParameterBase pas in passiveObject.passiveParameters)
                {
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
    }
}
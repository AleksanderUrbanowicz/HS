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

        public List<DynamicParameter> parameters = new List<DynamicParameter>();


        public PluggableDynamicParams(List<DynamicParameter> _parameters)
        {
            parameters = _parameters;


        }

        public PluggableDynamicParams()
        {


        }

        public PluggableParams ToPluggableParams()
        {
            PluggableParams parameters = new PluggableParams();
            foreach (DynamicParameter par in this.parameters)
            {
                parameters.parameters.Add(par as ParameterBase);

            }


            return parameters;
        }

        public PluggableDynamicParams GetInteractableParams()
        {
            PluggableDynamicParams par = new PluggableDynamicParams();
            foreach (DynamicParameter dynamicPar in parameters)
            {
                if (Config.GlobalConfig.interactionParameters.Contains(dynamicPar.id))
                {
                    par.parameters.Add(new DynamicParameter(dynamicPar.id, dynamicPar.value, dynamicPar.changeRate));

                }

            }


            return par;
        }
    }
    [Serializable]
    public class PluggableParams
    {

        public List<ParameterBase> parameters = new List<ParameterBase>();

        public PluggableParams(List<ParameterBase> _parameters)
        {
            parameters = _parameters;

        }


        public PluggableParams()
        {


        }




        public int GetIndexOfActive(string _id)
        {
            //int i = -1;

            ParameterBase par = parameters.FirstOrDefault(x => x.id == _id);
            if (par != null)
            {
                int i = parameters.IndexOf(par);

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

                    selected.parameters.Add(new ParameterBase(parameters[index].id, parameters[index].value));
                }

            }
            return selected;
        }

        public PluggableParams GetInteractableParams()
        {
            PluggableParams par = new PluggableParams();
            foreach (ParameterBase parActive in parameters)
            {
                if (Config.GlobalConfig.interactionParameters.Contains(parActive.id))
                {
                    par.parameters.Add(new ParameterBase(parActive.id, parActive.value));

                }

            }
            return par;
        }







        public void Add(ParameterBase parameterBase)
        {
            foreach (ParameterBase par in parameters)
            {
                if (par.id == parameterBase.id)
                {
                    par.value += parameterBase.value;

                }


            }

        }

        public ParameterBase Get(string _id)
        {
            foreach (ParameterBase par in parameters)
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
using EditorTools;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Characters
{
    [CreateAssetMenu(fileName = "CharacterData", menuName = "Characters/Character Data")]

    public class CharacterDataBase : ScriptableObject
    {
        public string id, displayName;
        public GameObject prefab;

        public string characterType;

        private List<ParameterBase> dynamicBaseParameters = new List<ParameterBase>();
        private List<ParameterBase> staticBaseParameters = new List<ParameterBase>();


        public List<ParameterBase> staticParameters = new List<ParameterBase>();
        public List<ParameterBase> dynamicParameters = new List<ParameterBase>();

      //  public List<ParameterBase> StaticParameters { get => (this as IPluggableParameters).GetAccumulatedStaticParameters(); set => staticParameters = value; }
      //  public List<ParameterBase> DynamicParameters { get => (this as IPluggableParameters).GetAccumulatedDynamicParameters(); set => dynamicParameters = value; }



        public CharacterDataBase()
        {
          
            characterType = "CharacterDataBase";

        }

      public  void OnEnable()
        {

        }

         List<ParameterBase> GetAccumulatedDynamicParameters()
        {
            List<ParameterBase> accumulatedParams = dynamicParameters;
            foreach (ParameterBase par in dynamicBaseParameters)
            {
                if (accumulatedParams.Contains(par))
                {
                    accumulatedParams[accumulatedParams.IndexOf(par)].value += par.value;
                }
                else
                {
                    accumulatedParams.Add(par);

                }
                
            }
          
            return accumulatedParams;
        }

        List<ParameterBase> GetAccumulatedStaticParameters()
        {

            List<ParameterBase> accumulatedParams = staticParameters;
            foreach (ParameterBase par in staticBaseParameters)
            {
                if (accumulatedParams.Contains(par))
                {
                    accumulatedParams[accumulatedParams.IndexOf(par)].value += par.value;
                }
                else
                {
                    accumulatedParams.Add(par);

                }

            }
            return accumulatedParams;
        }
    }
    }
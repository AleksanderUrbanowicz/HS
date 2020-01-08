using System;
using UnityEngine;

namespace Data
{
    [Serializable]
    public class BuildObjectMaterialData
    {
        public Material defaultMaterial;
        public Texture2D dirtyMask, damagedMask;

        //[ConfigSelector(ParamsSetKey = StringDefines.MaterialSetSelectorKey)]
        public string materialSet;
    }
}
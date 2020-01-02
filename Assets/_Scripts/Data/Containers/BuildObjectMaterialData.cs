using Assets._Scripts.Data.Definitions;
using Assets._Scripts.EditorUtilities;
using System;
using UnityEngine;

namespace Assets._Scripts.Data.Containers
{
    [Serializable]
    public class BuildObjectMaterialData
    {
        public Material defaultMaterial;
        public Texture2D dirtyMask, damagedMask;

        [ConfigSelector(ParamsSetKey = StringDefines.MaterialSetSelectorKey)]
        public string materialSet;
    }
}
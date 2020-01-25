
using System;
using UnityEngine;

namespace UI
{
    [Serializable]
    public class PluggableColor
    {
        [PluggableAssetSelector(AssetTypeKey = "Color")]
        public string id;
        public Color color;
    }
}
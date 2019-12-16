using EditorTools;
using UnityEngine;


public class PluggableMonoBehaviour : MonoBehaviour
{
    public PluggableParams totalParams = new PluggableParams();

    public void OnEnable()
    {


        // Config.GlobalConfig.AllPluggables.Add(this);
        Config.RegisterPluggable(this);



    }

    public void OnDisable()
    {
        ///Config.GlobalConfig.AllPluggables.Remove(this);
        Config.UnregisterPluggable(this);
    }

    public override string ToString()
    {


        return base.ToString();
    }




}

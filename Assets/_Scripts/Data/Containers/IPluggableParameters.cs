namespace Assets._Scripts.Data.Containers
{
    public interface IPluggableParameters
    {

        PluggableParams GetAccumulatedParameters();

        void AddIndividualParameters();

    }
}
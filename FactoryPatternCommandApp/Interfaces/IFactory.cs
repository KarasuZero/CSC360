namespace FactoryPatternCommandApp.Interfaces
{
    //creator
    public interface IFactory
    {
        IOutput getOutput(string outputType);
    }
}
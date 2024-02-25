namespace Application.Interfaces.Services
{
    public interface IXMLGeneratorService
    {
        void GetXMLFromObject(StreamWriter writer, object o);
    }
}

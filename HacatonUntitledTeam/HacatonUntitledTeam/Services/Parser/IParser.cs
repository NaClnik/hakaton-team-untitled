using AngleSharp.Dom;

namespace HacatonUntitledTeam.Services.Parser
{
    public interface IParser<T> where T : class
    {
        T Parse(IDocument document);
    } // IParser
}

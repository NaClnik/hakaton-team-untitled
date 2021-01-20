namespace HacatonUntitledTeam.Services.Parser
{
    public interface IParserSettings
    {
        // Свойства интерфейса.
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        int StartPoint { get; set; }
        int EndPoint { get; set; }
    } // IParserSettings.
}

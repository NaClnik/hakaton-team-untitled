using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HacatonUntitledTeam.Services.Parser.CurrentParsers.RozetkaParser
{
    public class RozetkaParserSettings : IParserSettings
    {
        public string BaseUrl { get; set; }
        public string Prefix { get; set; } = "page={CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }

        // Конструктор.
        public RozetkaParserSettings(string baseUrl, int startPoint, int endPoint)
        {
            BaseUrl = baseUrl;
            StartPoint = startPoint;
            EndPoint = endPoint;
        } // ctor.
    } // RozetkaParserSettings.
}

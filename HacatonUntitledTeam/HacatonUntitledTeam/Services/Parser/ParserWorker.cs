﻿using System;
using System.Threading.Tasks;
using AngleSharp;

namespace HacatonUntitledTeam.Services.Parser
{
    public class ParserWorker<T> where T : class
    {
        // Поля класса.

        // Свойства класса.
        public IParser<T> Parser { get; set; }
        public IParserSettings ParserSettings { get; set; }
        public HtmlLoader HtmlLoader { get; set; }
        public bool IsActive { get; private set; }

        // События класса.
        public event Action<object, T> NewData;
        public event Action<object> Completed; 

        // Ансамбль конструкторов.
        public ParserWorker(IParser<T> parser)
        {
            Parser = parser;
        } // ctor.

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            ParserSettings = parserSettings;
        } // ctor.

        // Методы класса.
        public async void Start()
        {
            IsActive = true;
            await Work();
        } // Start.

        public void Abort()
        {
            IsActive = false;
        } // Abort.

        private async Task Work()
        {
            for (int i = ParserSettings.StartPoint; i < ParserSettings.EndPoint; i++)
            {
                if(!IsActive)
                    return;

                var source = await HtmlLoader.GetSourceByPageId(i);

                var context = BrowsingContext.New(Configuration.Default);

                var document = await context.OpenAsync(req => req.Content(source));

                var result = Parser.Parse(document);

                // Зажигаем событие "Появились новые данные".
                OnNewData(this, result);
            } // for.

            IsActive = false;

            // Зажигаем событие "Парсинг завершился".
            OnCompleted(this);
        } // Work.

        // Зажигатели событий.
        protected virtual void OnNewData(object arg1, T arg2)
        {
            NewData?.Invoke(arg1, arg2);
        } // OnNewData.

        protected virtual void OnCompleted(object obj)
        {
            Completed?.Invoke(obj);
        } // OnCompleted.
    } // ParserWorker.
}

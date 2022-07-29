using Calendar_VK_MyGames.Models;
using ET.FakeText;
using System;
using System.Collections.Generic;

namespace Calendar_VK_MyGames.Core
{
    public class EventsSource //Источник тестовых данных
    {
        public List<EventBody> GetEventsExamples()
        {
            List<EventBody> eventBodies = new List<EventBody>();

            for (int i = 0; i < 10; i++) //Генерируем 10 тестовых событий
            {
                DateTime gen_date = GenerateDate();
                EventBody eventBody = new EventBody
                {
                    Event_ID = Guid.NewGuid().GetHashCode(),
                    Event_Color = GenerateColor(),
                    Event_Comment = GenerateText(),
                    Event_Label = GenerateName(),
                    Event_ForeColor = "#FFFFFF",
                    Event_DateStart = gen_date,
                    Event_DateEnd = gen_date,
                };
                eventBodies.Add(eventBody);
            }


            return eventBodies;
        }

        public int GetRandom()
        {
            return 5; //Не совсем честный рандом, ограничивает возможную длину фразы
        }

        public string GenerateName() //Создаём рыбу-текст для названия события
        {
            TextGenerator wc = new TextGenerator();
            return wc.GenerateWord(GetRandom());
        }

        public string GenerateText()//Создаём рыбу-текст для текста события
        {
            TextGenerator wc = new TextGenerator();
            return wc.GenerateText(GetRandom());
        }

        public string GenerateColor() //Выбираем случайный цвет из коллекции
        {

            List<string> Colors = new List<string>();

            Colors.Add("#ADFF2F");
            Colors.Add("#7FFF00");
            Colors.Add("#7CFC00");
            Colors.Add("#00FF00");
            Colors.Add("#32CD32");
            Colors.Add("#98FB98");
            Colors.Add("#90EE90");
            Colors.Add("#00FA9A");
            Colors.Add("#00FF7F");
            Colors.Add("#3CB371");
            Colors.Add("#2E8B57");
            Colors.Add("#228B22");
            Colors.Add("#008000");
            Colors.Add("#006400");
            Colors.Add("#9ACD32");
            Colors.Add("#6B8E23");
            Colors.Add("#808000");
            Colors.Add("#556B2F");
            Colors.Add("#66CDAA");
            Colors.Add("#8FBC8F");
            Colors.Add("#20B2AA");
            Colors.Add("#008B8B");
            Colors.Add("#008080");
            Colors.Add("#808080");
            Colors.Add("#848482");
            Colors.Add("#8D918D");
            Colors.Add("#A9A9A9");
            Colors.Add("#B6B6B4");
            Colors.Add("#C0C0C0");
            Colors.Add("#C9C0BB");
            Colors.Add("#D1D0CE");
            Colors.Add("#CECECE");
            Colors.Add("#D3D3D3");
            Colors.Add("#DCDCDC");
            Colors.Add("#E5E4E2");
            Colors.Add("#BCC6CC");
            Colors.Add("#98AFC7");
            Colors.Add("#838996");
            Colors.Add("#778899");
            Colors.Add("#708090");
            Colors.Add("#6D7B8D");

            Random rnd = new Random();
            int buffer = rnd.Next(0, Colors.Count);
            return Colors[buffer];


        }

        public DateTime GenerateDate() //Выбираем случайную дату
        {
            DateTime dt_current = DateTime.Now;

            int date_of_month = 1;
            int month_length = DateTime.DaysInMonth(dt_current.Year, dt_current.Month);

            var random = new Random();
            int new_day = random.Next(date_of_month, month_length);

            return new DateTime(dt_current.Year, dt_current.Month, new_day);
        }

        public DateTime GenerateOffsetDate(DateTime start_date) //И случайное смещение по дате - в билде отключены события длительностью >1 дня по умолчанию
        {
            DateTime endDate = start_date;
            int date_of_month = start_date.Day;
            int month_length = DateTime.DaysInMonth(start_date.Year, start_date.Month);

            var random = new Random();
            int new_day = random.Next(month_length, date_of_month);

            return new DateTime(start_date.Year, start_date.Month, new_day);
        }

    }
}

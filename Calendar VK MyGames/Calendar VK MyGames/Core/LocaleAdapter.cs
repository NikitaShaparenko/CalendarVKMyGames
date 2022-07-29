using System;
using System.Globalization;

namespace Calendar_VK_MyGames.Core
{
    public class LocaleAdapter
    {
        public static int NumDateConverter(int num_of_day)
        {
            if (num_of_day < 0) return 0;

            if (num_of_day > 6)
            {
                num_of_day %= 7;
            }

            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            if (firstDayOfWeek == DayOfWeek.Saturday)
            {
                if (num_of_day == 0) num_of_day = 6;
                if (num_of_day == 7) num_of_day = 0;
            }
            else if (firstDayOfWeek == DayOfWeek.Monday)
            {
                if (num_of_day >= 0) num_of_day++;
                if (num_of_day == 7) num_of_day = 0;
            }

            return num_of_day;
        }
    }
}

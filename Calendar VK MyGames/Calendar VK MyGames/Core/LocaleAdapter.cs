using System;
using System.Globalization;

namespace Calendar_VK_MyGames.Core
{
    public class LocaleAdapter
    {
        public static int NumDateConverter(int num_of_day) //Ввиду разных настроек пользовательской ОС, у всех неделя начинается в разный день недели - в СБ, ВС или ПН.
        {
            if (num_of_day < 0) return 0; //Фикс левых данных

            if (num_of_day > 6) //Зацикливаем неделю
            {
                num_of_day %= 7;
            }

            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek; //Получаем первый день недели из настроек ОС пользователя

            if (firstDayOfWeek == DayOfWeek.Saturday) //Фикс начала недели с субботы
            {
                if (num_of_day == 0) num_of_day = 6;
                if (num_of_day == 7) num_of_day = 0;
            }
            else if (firstDayOfWeek == DayOfWeek.Monday) //Фикс начала недели с понедельника
            {
                if (num_of_day >= 0) num_of_day++;
                if (num_of_day == 7) num_of_day = 0;
            }

            return num_of_day;
        }
    }
}

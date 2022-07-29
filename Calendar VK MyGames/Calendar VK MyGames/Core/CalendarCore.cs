using Microsoft.AspNetCore.Components;

namespace Calendar_VK_MyGames.Core
{
    public abstract class CalendarCore : ComponentBase
    {
        //Разрешает пользователю перемещать задачи
        [Parameter]
        public bool IsDraggable { get; set; } = true;


        public enum CalendarModalCallingEvents //Варианты взаимодействия с задачей
        {
            Create, //Создать
            View, //Просмотреть
            Edit //Удалить
        }


        #region Параметры стилей        

        [Parameter]

        public static string Style_Bg_WeekendColor_Saturday { get; set; } = "rgba(0,255,127,0.5)"; //Spring Green,#00FF7F

        [Parameter]
        public static string Style_Bg_WeekendColor_Sunday { get; set; } = "rgba(0,255,127,0.7)"; //Spring Green,#00FF7F

        [Parameter]
        public static string Style_Header_WeekendColor { get; set; } = "rgba(0,255,127,1)"; //Spring Green, rgba(0,255,127,1) #00FF7F

        [Parameter]
        public static string Style_Bg_DailyColor { get; set; } = "rgba(240,255,255,0.7)"; //Azure, rgba(240,255,255,0.5) #F0FFFF

        [Parameter]
        public static string Style_Header_DailyColor { get; set; } = "rgba(105,105,105,1)"; //DimGrey, rgba(105,105,105) #696969

        [Parameter]
        public static string Style_Header_Selection { get; set; } = "rgba(30,144,255,1)"; //DodgerBlue, rgba(30,144,255,1)

        #endregion

    }
}

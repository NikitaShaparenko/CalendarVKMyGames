using System;
using System.Collections.Generic;

namespace Calendar_VK_MyGames.Models
{
    public class Click_Event //Модель, использующаяся при клике по событию
    {
        public List<int> ID_lst { get; set; } //ID события

        public double X { get; set; } //Координаты
        public double Y { get; set; }
    }

    public class Click_EmptyDay //Модель, использующаяся при клике на пустой день
    {
        public DateTime Day { get; set; } //Дата события
        public double X { get; set; } //Координаты
        public double Y { get; set; }
    }

    public class DragDrop //Модель для драг-дропа
    {
        public DateTime Day { get; set; } //Дата события
        public int taskID { get; set; } //ID события
    }

    public class Positioner //Модель для позиционирования в дне - показываются первые 2 события в дне 
    {
        public int Counter { get; set; } //Счётчик событий в дне
        public bool Top { get; set; } //Событие сверху
        public bool Center { get; set; } //Событие посередине
    }

    public class EventBody //Модель структуры события
    {
        public int Event_ID { get; set; } //ID события
        public string Event_Label { get; set; } //Подпись события
        public string Event_Color { get; set; } //Цвет заднего фона события
        public string Event_ForeColor { get; set; } = null; //Цвет шрифта события
        public string? Event_Comment { get; set; } = null; //Комментарий к событию
        public DateTime Event_DateStart { get; set; } //Дата начала события
        public DateTime Event_DateEnd { get; set; } //Дата конца соыбтия

        public bool Event_isAllDay { get; set; } = true; //Индикатор события на весь день
    }
}

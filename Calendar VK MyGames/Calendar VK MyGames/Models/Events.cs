using System;
using System.Collections.Generic;

namespace Calendar_VK_MyGames.Models
{
    public class Click_Task
    {
        public List<int> ID_lst { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Click_EmptyDay
    {
        public DateTime Day { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class DragDrop
    {
        public DateTime Day { get; set; }
        public int taskID { get; set; }
    }

    public class Positioner
    {
        public int Counter { get; set; }
        public bool Top { get; set; }
        public bool Center { get; set; }
    }

    public class EventBody
    {
        public int Event_ID { get; set; }
        public string Event_Label { get; set; }
        public string Event_Color { get; set; }
        public string Event_ForeColor { get; set; } = null;
        public string? Event_Comment { get; set; } = null;
        public DateTime Event_DateStart { get; set; }
        public DateTime Event_DateEnd { get; set; }

        public bool Event_isAllDay { get; set; } = true;
    }
}

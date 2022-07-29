using Microsoft.AspNetCore.Components.Web;
using System;
using System.Threading.Tasks;
using Calendar_VK_MyGames.Models;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using Calendar_VK_MyGames.Core;
using System.Collections.Generic;
using System.Linq;

namespace Calendar_VK_MyGames.Pages
{
    public partial class Index
    {
        public List<EventBody> EventsCollection { get; set; }
        private EventBody TaskDragged;

        readonly string[] weekdays_short = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
        readonly string[] weekdays = CultureInfo.CurrentCulture.DateTimeFormat.DayNames;

        enum DayInMonthPosition
        {
            DayInMonthBefore,
            DayInCurrentMonth,
            DayInNextMonth,
        }

        private Task ClickDay(MouseEventArgs e, DateTime day)
        {
            Click_EmptyDay click_EmptyDay = new()
            {
                Day = day,
                X = e.ClientX,
                Y = e.ClientY
            };

            modal_cmce = CalendarModalCallingEvents.Create;
            modal_date = day;
            modal_event_id = Guid.NewGuid().GetHashCode();

            EventsSource es = new EventsSource();
            EventBody ev_b = new EventBody();
            ev_b.Event_Comment = "";
            ev_b.Event_Color = es.GenerateColor();
            ev_b.Event_ForeColor = "#FFFFFF";
            ev_b.Event_Label = "";
            ev_b.Event_ID = modal_event_id;
            ev_b.Event_DateStart = day;
            ev_b.Event_DateEnd = day;
            ev_b.Event_isAllDay = true;

            modal_model = ev_b;
            OpenModal();

            return Task.CompletedTask;

            //await DayClick.InvokeAsync(clickEmptyDay);
        }

        private void Click_AllDay(MouseEventArgs e, DateTime day)
        {
            if (day == default) return;

            // There can be several tasks in one day :
            List<int> listID = new();
            if (EventsCollection != null)
            {
                foreach (var ev_b in EventsCollection)
                {
                    if (ev_b.Event_DateStart.Date <= day.Date && day.Date <= ev_b.Event_DateEnd.Date)
                    {
                        listID.Add(ev_b.Event_ID);
                    }
                }

               Click_Task clickTaskParameter = new()
                {
                    ID_lst = listID,
                    X = e.ClientX,
                    Y = e.ClientY
                };

                //await TaskClick.InvokeAsync(clickTaskParameter);
            }
        }

        private Task Handler_DragStart(int taskID)
        {
            TaskDragged= new EventBody()
            {
                Event_ID = taskID
            };

            DragDrop dragDrop = new()
            {
                taskID = TaskDragged.Event_ID
            };
            return Task.CompletedTask;
            //await DragStart.InvokeAsync(dragDropParameter);
        }

        private int getEventArrID_byTaskID(int task_id)
        {
            int i = int.MinValue;

            for(int z = 0; z<EventsCollection.Count; z++)
            {
                if (EventsCollection[z].Event_ID == task_id)
                {
                    return z;
                }
            }
            return i;
        }

        private Task Click_Event(MouseEventArgs e, int taskID)
        {
            List<int> listID = new();
            listID.Add(taskID);

            Click_Task click_task = new()
            {
                ID_lst = listID,
                X = e.ClientX,
                Y = e.ClientY
            };

            int event_arr_place = getEventArrID_byTaskID(taskID);
            
            if (event_arr_place != int.MinValue)
            {
                modal_date = EventsCollection[event_arr_place].Event_DateStart;
           
            modal_event_id = taskID;
            modal_cmce = CalendarModalCallingEvents.Edit;

            EventsSource es = new EventsSource();
            EventBody ev_b = new EventBody();
            ev_b.Event_Comment = EventsCollection[event_arr_place].Event_Comment;
            ev_b.Event_Color = es.GenerateColor();
            ev_b.Event_ForeColor = "#FFFFFF";
            ev_b.Event_Label  = EventsCollection[event_arr_place].Event_Comment;
                ev_b.Event_ID = EventsCollection[event_arr_place].Event_ID;
            ev_b.Event_DateStart = EventsCollection[event_arr_place].Event_DateStart;
                ev_b.Event_DateEnd = EventsCollection[event_arr_place].Event_DateEnd;
                ev_b.Event_isAllDay = EventsCollection[event_arr_place].Event_isAllDay;

                modal_model = ev_b;
            }
            OpenModal();



            return Task.CompletedTask;

            //await TaskClick.InvokeAsync(clickTaskParameter);
        }

        private void HandleDayOnDrop(DateTime day)
        {
            if (!IsDraggable) return;
            if (TaskDragged == null) return;

            DragDrop dragDrop = new()
            {
                Day = day,
                taskID = TaskDragged.Event_ID
            };

            EventBody task_dropped = EventsCollection.FirstOrDefault(p => p.Event_ID == dragDrop.taskID);

            var TotalDay = (task_dropped.Event_DateEnd - task_dropped.Event_DateStart).TotalDays;
            task_dropped.Event_DateEnd = dragDrop.Day.AddDays(TotalDay);
            task_dropped.Event_DateStart = dragDrop.Day;

            //await DropTask.InvokeAsync(dragDrop);

            TaskDragged = null;
        }

        private string DayColoring(DateTime day)
        {
            switch (day.DayOfWeek)
            {

                case DayOfWeek.Saturday:
                    return "background:" + CalendarCore.Style_Bg_WeekendColor_Saturday;

                case DayOfWeek.Sunday:
                    return "background:" + CalendarCore.Style_Bg_WeekendColor_Sunday;

                default:
                    return "background:" + CalendarCore.Style_Bg_DailyColor;
            }
        }

        private void DraggableButtonClickInterpreter()
        {
            IsDraggable = !IsDraggable;
            StateHasChanged();
        }
    }


}

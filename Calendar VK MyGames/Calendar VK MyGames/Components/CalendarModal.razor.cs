using Calendar_VK_MyGames.Core;
using Calendar_VK_MyGames.Models;
using System;

namespace Calendar_VK_MyGames.Components
{
    public partial class CalendarModal
    {
        private void CloseModal() //Закрытие модального окна
        {
            CalendarModalOpened = false;
            OnClose.InvokeAsync(true);
        }

        private void KillModal() //Передать ID в родительское окно, чтобы убить событие
        {
            OnKilling.InvokeAsync(Event_ID);
            CloseModal();
        }

        private void SaveModal() //Сохранение события
        {
            EventsSource es = new EventsSource();

            if (model.Event_EndDateTime < model.Event_StartDateTime) //Фикс попытки ввести дату конца раньше, чем начала
            {
                DateTime dt = model.Event_StartDateTime;
                model.Event_StartDateTime = model.Event_EndDateTime;
                model.Event_EndDateTime = dt;
            }

            EventBody ev_b = new EventBody //Создаётся локальное событие
            {
                Event_ID = Event_ID,
                Event_Color = es.GenerateColor(),
                Event_Comment = model.Event_Text,
                Event_Label = model.Event_Text,
                Event_ForeColor = "#FFFFFF",
                Event_DateStart = model.Event_StartDateTime,
                Event_DateEnd = model.Event_EndDateTime,
                Event_isAllDay = model.isAllDay,

            };
            OnSaving.InvokeAsync(ev_b); //Отправляется в родительскую форму для создания или сохранения изменений
            CloseModal();

        }


    }
}

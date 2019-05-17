using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBlazorApp.Shared.Events
{
    public class NewEventSent : IntegrationEvent
    {
        public string Message { get; private set; }

        public NewEventSent(string message)
        {
            Message = message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Terminal_or_Address
{
    public class JsonAccept
    {
        public data data { get; set; } = new data();

        public List<errors> errors { get; set; } = new List<errors>();
    }
    public class errors
    {
        public string detail { get; set; }
    }
    public class data
    {
        public string price { get; set; } // Цена доставка
        public string insurance { get; set; } // Цена страхования груза
        public orderDates orderDates { get; set; } = new orderDates();
    }
    public class orderDates
    {
        public string pickup { get; set; } // Дата передачи груза на адрес отпраправителя
        public string derivalFromOspSender { get; set; } // Дата отправки
        public string arrivalToOspReceiver { get; set; } // Дата прибытия на терминал поулчателя
        public string derivalFromOspReceiver { get; set; } // Дата отправки с терминала, получателю
    }
}

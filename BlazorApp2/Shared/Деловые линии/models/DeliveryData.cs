using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.models
{
    public class ResponseDeliveryData
    {
        public metadatas metadata { get; set; } = new metadatas();
        public datas data { get; set; } = new datas();
        public List<errorss> errors { get; set; } = new List<errorss>();
        public class errorss
        {
            public string detail { get; set; }
        }
        public class metadatas
        {
            public int status { get; set; }
            public string generated_at { get; set; }

        }
        public class datas
        {
            public derival derival { get; set; } = new derival();   
            public orderDates orderDates { get; set; } = new orderDates();
            public string price { get; set; } // итоговая цена
            public string insurance { get; set; } // Общая стоимость страхования груза
        }
        public class derival
        {
            public List<terminals> terminals { get; set; } = new List<terminals>();
        }
        public class terminals
        {
            public int id { get; set; }
            public string address { get; set; }

        }
   
        public class arrival
        {
            public List<terminalss> terminalsses { get; set; } = new List<terminalss>();
        }
        public class terminalss
        {
            public string address { get; set; }
        }
        public class orderDates
        {
            public string? pickup { get; set; }
            public string arrivalToOspSender { get; set; } // Дата прибытия на терминал отправителя
            public string derivalFromOspSender { get; set; } // дата отправки с терминала
            public string arrivalToOspReceiver { get; set; } // дата прибытия на терминал получателя

        }

    }
    

}

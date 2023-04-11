using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.СДЭК
{
    public class JsonAceptSDEC
    {
        public requests requests { get; set; } = new requests();
        public List<tariff_codes> tariff_codes { get; set; } = new List<tariff_codes>();
        public string _error { get; set; }
    }
    public class requests
    {
        public string type { get; set; }
    }
    public class tariff_codes
    {
        public int tariff_code { get; set; } // Код доставки
        public string tariff_name { get; set; } // Тариф
        public decimal delivery_sum { get; set; } // Сумма доставки
        public decimal _priceStrah { get; set; } // Сумма страховки
        public int period_min { get; set; } //  Минимальная дата доставки в рабочих днях
        public int period_max { get; set; } //  Максимальная дата доставки в рабочих днях
    }
}

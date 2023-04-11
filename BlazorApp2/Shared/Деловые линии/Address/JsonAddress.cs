using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Address
{
    public class JsonAddress
    {
        public string? appkey { get; set; } = "68CFEB96-2729-47C9-869F-AB77FDFB4614";

        public deliverys delivery { get; set; } = new deliverys();
        public cargo? cargo { get; set; } = new cargo();
    }
    public class deliverys
    {
        public deliveryTypes deliveryType { get; set; } = new deliveryTypes();
        public arrivals arrival { get; set; } = new arrivals();
        public derivals derival { get; set; } = new derivals();
   

        public string? variant { get; set; }


    }
    public class cargo
    {
        public double? quantity { get; set; } = 1; // Кол-во грузовых мест
        public double? length { get; set; } // Длина груза
        public double? width { get; set; }  // Ширина груза
        public double? height { get; set; }  // Высота груза
        public decimal? totalVolume { get; set; }

        public double? totalWeight { get; set; } // Общий вес
        public double oversizedWeight { get; set; } = 0;  // Вес негабаритных грузовых мест

        public double oversizedVolume { get; set; } = 0; // Объем Негабаритных грузовых мест
        public int? hazardClass { get; set; } = 0;

    }
    public class deliveryTypes
    {
        public string type { get; set; } = "auto";
    }
    public class arrivals // Получатель
    {
        public string variant { get; set; } = "address"; // Пункт откуда поедет, терминал или склад

        public address address { get; set; } = new address();
        public time time { get; set; } = new time();
    }
    public class address
    {
        public string search { get; set; }
    }
    public class derivals // Отправитель
    {
        public DateTime? produceDated { get; set; }
        public string? produceDate { get; set; }
        public string variant { get; set; } = "address";
        public time time { get; set; } = new time();
        public address address { get; set; } = new address();
    }
    public class time
    {
        public string worktimeStart { get; set; } // Время отправки груза из адреса
        public string worktimeEnd { get; set; } // Время прибытия груза на адрес

    }
 

}

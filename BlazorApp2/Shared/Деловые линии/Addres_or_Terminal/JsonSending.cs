using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Addres_or_Terminal
{
    public class JsonSendingAdres
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
        public float? quantity { get; set; } = 1; // Кол-во грузовых мест
        public float? length { get; set; } // Длина груза
        public float? width { get; set; }  // Ширина груза
        public float? height { get; set; }  // Высота груза
        public decimal? totalVolume { get; set; }

        public float? totalWeight { get; set; } // Общий вес
        public float? oversizedWeight { get; set; } = 0;  // Вес негабаритных грузовых мест

        public float oversizedVolume { get; set; } = 0; // Объем Негабаритных грузовых мест
        public int? hazardClass { get; set; } = 0;

    }
    public class deliveryTypes
    {
        public string type { get; set; } = "auto";
    }
    public class arrivals // Получатель
    {
        public string variant { get; set; } = "terminal"; // Пункт откуда поедет, терминал или склад
        public int terminalID { get; set; }
    }
   
    public class derivals // Отправитель
    {
        public DateTime? produceDated { get; set; }

        public string? produceDate { get; set; }
        public string variant { get; set; } = "address";
        public address address { get; set; } = new address();
        public time time { get; set; } = new time(); 

    }
    public class address
    {
        public string search { get; set; }
    }
    public class time
    {
        public string worktimeStart { get; set; } // Время отпрапвки груза из адреса
        public string worktimeEnd { get; set; } // Время прибытия груза на адрес
    }
}

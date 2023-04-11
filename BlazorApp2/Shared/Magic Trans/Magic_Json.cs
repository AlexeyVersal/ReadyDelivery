using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Magic_Trans
{
    public class Magic_Json
    {
        public bool status { get; set; } = false;
        public int error { get; set; }
        public string? message { get; set; }

        public List<results>? result { get; set; }

    }
    public class results
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool terminal { get; set; }
        public bool delivery { get; set; }
    }

    public class RequestData
    {
        public int from { get; set; } // Город отправителя
        public int to { get; set; } // Город получателя
        public int count { get; set; } = 1; // Кол-во позиций
        public int priceStrah { get; set; } // Объявленаяч стоимость груза
        public decimal weight { get; set; } // Вес одной позиции
        public decimal volume { get; set; } // Объем груза однйо позиции м3
        public decimal length { get; set; } // Длина
        public decimal width { get; set; } // Ширина
        public decimal height { get; set; } // Высота


    }
    public class ResultMagicTrans
    {
        public string? message { get; set; }
        public int error { get; set; }
        public decimal _sumStrah { get; set; }
        public ResultAll result { get; set; }
    }
    public class ResultAll
    {
        public decimal price { get; set; }
        public decimal _sumStrah { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.Tk_Kit
{
    public class AllInfo
    {
        public List<CityInfo> cityInfo { get; set; } = new List<CityInfo>();
        public ErrorFindCity? errorFindCity { get; set; }
        public string? message { get; set; }
    }
    public class CityInfo
    {
        public string? message { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public string? type { get; set; }
        public string? country_code { get; set; }
        public int? required_pickup { get; set; }
        public int? required_delivery { get; set; }
    }
    public class ErrorFindCity
    {
        public string message { get; set; }
        public int status { get; set; }
    }
    public class NameCity
    {
        public string title { get; set; }

    }
    public class RequestTkKit
    {
        public string city_pickup_code { get; set; } // Отправитель
        public string city_delivery_code { get; set; } // Получатель
        public int declared_price { get; set; }
        public int confirmation_price { get; set; }
        public List<Places> places { get; set; } = new List<Places>();
    }
    public class Places
    {
        public int count_place { get; set; } = 1;
        public decimal height { get; set; } // ВЫсота груза (см)
        public decimal width { get; set; } // Ширина груза (см)
        public decimal length { get; set; } // Длина груза (см)
        public decimal weight { get; set; } // Масса груз (кг)
        public decimal volume { get; set; } // Объем груза (м3)

    }
    public class Result
    {
        public List<ResultTkKit>? resultTkKits { get; set; }
        public List<string> errors { get; set; } = new List<string>();

    }
    public class ResultTkKit
    {
        public Standart standart { get; set; }
        public Express express { get; set; }

    }
    public class Standart
    {
        public string name { get; set; }
        public int cost { get; set; }
        public int time { get; set; }
        public List<Detail> detail { get; set; } = new List<Detail>();
    }
    public class Express
    {
        public string name { get; set; }
        public int cost { get; set; }
        public int time { get; set; }
        public List<Detail> detail { get; set; } = new List<Detail>();
    }
    public class Detail
    {
        public string name { get; set; }
        public int price { get; set; }

    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.PEC
{
    public class JsonPecSearch
    {
        public int nameCityFrom { get; set; }
        public int deliver_town { get; set; }
        public int strah { get; set; } // Сумма страхования
        public decimal width { get; set; }
        public decimal length { get; set; }
        public decimal height { get; set; }
        public decimal volume { get; set; }
        public int weight { get; set; }

    }
    public class DataCity
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class ResultPec
    {
        public decimal sumSkladAndSklad { get; set; }
        public decimal sumDorAndDor { get; set; }
        public decimal sumSkladandDor { get; set; }
        public decimal sumDorAndSklad { get; set; }
        public int priceStrah { get; set; }
        public string periods { get; set; }
        public string error { get; set; }
    }

}

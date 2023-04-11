using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.СДЭК
{
    public class JsonSDEC
    {
        public int type { get; set; } = 1;
        public int currency { get; set; } = 1;
        public string lang { get; set; } = "rus";
        public int _sumStrah { get; set; }
        public from_location from_location { get; set; } = new from_location();
        public to_location to_location { get; set; } = new to_location();

        public packages? packages { get; set; } = new packages();
    }
    public class from_location // Отправитель
    {
        public string address { get; set; }
    }
    public class to_location
    {
        public string address { get; set; } 
    }
    public class packages
    {
        public decimal height { get; set; } //  Высота
        public decimal length { get; set; } // Длина
        public decimal weight { get; set; }// Общий вес
        public decimal width { get; set; } // Ширина

    }

}

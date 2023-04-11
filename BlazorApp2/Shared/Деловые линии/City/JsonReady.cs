using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.City
{
    public class JsonReady
    {
        public List<cities> cities { get; set; } = new List<cities>();
  

    }
    public class cities
    {
        public string aString { get; set; }
        public int isTerminal { get; set; } // Сколько терминалов есть в населенном пункте
        public string code { get; set; }
    }
    public class Terminals
    {
        public List<terminals> terminals { get; set; } = new List<terminals>();
    }
    public class terminals
    {
        public int id { get; set; }
        public string address { get; set; }
        [JsonPropertyName("default")]
        public bool Default { get; set; }
    }
    public class JsonReady2
    {
        public List<cities> cities { get; set; } = new List<cities>();


    }
    public class cities2
    {
        public string aString { get; set; }
        public int isTerminal { get; set; } // Сколько терминалов есть в населенном пункте
        public string code { get; set; }
    }
    public class Terminals2
    {
        public List<terminals> terminals { get; set; } = new List<terminals>();
    }
    public class terminals2
    {
        public int id { get; set; }
        public string address { get; set; }
        [JsonPropertyName("default")]
        public bool Default { get; set; }
    }
}


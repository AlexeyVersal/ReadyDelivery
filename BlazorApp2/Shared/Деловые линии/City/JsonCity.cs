using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp2.Shared.City
{
    public class JsonCity
    {
        public string appkey { get; set; } = "68CFEB96-2729-47C9-869F-AB77FDFB4614";
        public string q { get; set; }
        public int limit { get; set; } = 10;
    }
    public class JsonTerminals
    {
        public string appkey { get; set; } = "68CFEB96-2729-47C9-869F-AB77FDFB4614";
        public string code { get; set; }
    }
    public class JsonCity2
    {
        public string appkey { get; set; } = "68CFEB96-2729-47C9-869F-AB77FDFB4614";
        public string q { get; set; }
        public int limit { get; set; } = 10;
    }
    public class JsonTerminals2
    {
        public string appkey { get; set; } = "68CFEB96-2729-47C9-869F-AB77FDFB4614";
        public string code { get; set; }
    }

}

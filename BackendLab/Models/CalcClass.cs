using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLab.Models
{
    public class CalcClass
    {
        public string First { get; set; }
        public string Second { get; set; }
        public string Add { get; set; }
        public string Sub { get; set; }
        public string Mult { get; set; }
        public string Div { get; set; }

        public CalcClass() 
        {
            Random random = new Random();
            double First = random.Next(11);
            double Second = random.Next(11);
            Add = "" + (First + Second);
            Sub = "" + (First - Second);
            Mult = "" + (First * Second);
            Div = "" + (First / Second);
            this.First = First.ToString();
            this.Second = Second.ToString();
        }
    }
}

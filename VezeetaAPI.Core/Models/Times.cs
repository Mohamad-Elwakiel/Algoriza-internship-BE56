using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezeetaAPI.Core.Models
{
    public class Times
    {
        public int ID { get; set; } 
        public int requestID { get; set; }  
        public TimeSpan requestTime { get; set; }   

        public Requests requests { get; set; }  
    }
}

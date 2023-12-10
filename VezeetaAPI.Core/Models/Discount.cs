using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Constants;

namespace VezeetaAPI.Core.Models
{
    public  class Discount
    {
        public int DiscountId { get; set; } 
       public int patientId { get; set; }   
        public string DiscountCode { get; set; }    
        public DiscountType discountType { get; set; }  
        public int completedRequests { get; set; }
        public Patient patient { get; set; }    
    }
}

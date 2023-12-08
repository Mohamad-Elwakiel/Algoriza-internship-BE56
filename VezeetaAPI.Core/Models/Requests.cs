using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Constants;

namespace VezeetaAPI.Core.Models
{
    
    public class Requests
    {
        
        public int RequestsId { get; set; }
        public int DoctorId { get; set; }
        public RequestStatus RequestState { get; set; }
        public int PatientId { get; set; }
        public int price { get; set; }    
        public RequestDay requestDay { get; set; }  
        public Doctors Doctors { get; set; }    
        public Patient Patient { get; set; }    
        public List<Times> times { get; set; }      
    }
}

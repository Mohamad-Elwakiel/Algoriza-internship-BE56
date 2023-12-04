using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezeetaAPI.Core.Models
{
    
    public class Requests
    {
        
        public int RequestsId { get; set; }
        public int DoctorId { get; set; }
        public enum RequestStatus
        { 
            pending,
            completed,
            cancelled,
        }

        public RequestStatus RequestState { get; set; }
        public int PatientId { get; set; }
        public enum RequestDay
        {
            Saturday = 0,
            Sunday =1,  
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6

        }
        public RequestDay requestDay { get; set; }  
        public Doctors Doctors { get; set; }    
        public Patient Patient { get; set; }    
        public List<Times> times { get; set; }      
    }
}

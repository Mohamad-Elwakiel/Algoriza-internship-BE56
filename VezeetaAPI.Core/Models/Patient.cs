using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezeetaAPI.Core.Models
{
    public  class Patient 
    {
        public string Email { get; set; }   
        public int PatientId { get; set; }  
        public List<Requests> Requests { get; set; }

        public ApplicationUser User { get; set; }   

    }
}

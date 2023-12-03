using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezeetaAPI.Core.Models
{
    public class Doctors 
    {
        public int DoctorsId { get; set; }   
        public int SpeclizationID { get; set; }
        public string UserId { get; set; } 
        public List<Specalization> Specalizations { get; set; } 
        public List<Requests> Requests { get; set; }
        public ApplicationUser User { get; set; }

    }

}

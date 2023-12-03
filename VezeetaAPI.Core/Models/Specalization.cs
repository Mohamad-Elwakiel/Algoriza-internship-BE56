using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezeetaAPI.Core.Models
{
    public class Specalization
    {
        public int SpecalizationId { get; set; }
        public int DoctorId { get; set; }
        [MaxLength(150)]
        public string SpecalizationName { get; set; }   

        public Doctors Doctors { get; set; }    

    }
}

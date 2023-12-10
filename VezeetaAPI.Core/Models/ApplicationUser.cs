using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaAPI.Core.Constants;

namespace VezeetaAPI.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }
        public string ImageUrl { get; set; }    

        
        public Gender gender { get; set; }  
        

        public DateFormat DOB { get; set; }

        public string accountType { get; set; }

    }
}

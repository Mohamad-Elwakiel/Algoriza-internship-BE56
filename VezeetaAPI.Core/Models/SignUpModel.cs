﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VezeetaAPI.Core.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get;set; }
        [Required]
        public string  PhoneNumber { get; set; }
        public enum genderEnum
        { 
            Male = 1,
            Female = 0,
        }
        [Required]
        public genderEnum Gender { get; set; }
        [Required]
        public DateFormat DOB { get; set; } 

        public string accountType { get; set; }     
        public string ImageUrl { get; set; }    

    }
}

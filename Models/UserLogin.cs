﻿using System.ComponentModel.DataAnnotations;

namespace MiniHospitalProject.Models
{
    public class UserLoginModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public string role { get; set; }
    }
}


///

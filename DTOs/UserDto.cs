﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcommAPI.DTOs
{
    public class UserDto
    {
       
        public string? UserId { get; set; }
      
        public string? Name { get; set; }
       
        public string? Email { get; set; }
       
        public string? Mobile { get; set; }
      
        public string? Password { get; set; }
      
       
    }
}

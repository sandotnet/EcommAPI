﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcommAPI.Entities
{
    //POCO class(Plain Old CLR Oject)
    [Table("Users")]
    public class User
    {
        //Scalar Properties
        [Key] //Primary key
        [StringLength(5)] //set size as 5
        [Column(TypeName ="char")]
        public string? UserId { get; set; }
        [Required] 
        [StringLength(50)] 
        [Column("Username",TypeName = "varchar")]
        public string? Name { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Email", TypeName = "varchar")]
        public string? Email { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Phone", TypeName = "varchar")]
        public string? Mobile { get; set; }
        [Required]
        [StringLength(10)]
        [Column("Password",TypeName = "varchar")]
        public string? Password { get; set; }
        //Navigation Properties
    }
}

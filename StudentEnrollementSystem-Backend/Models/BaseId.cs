﻿using System.ComponentModel.DataAnnotations;

namespace StudentEnrollementSystem_Backend.Models
{
    public class BaseId
    {
        [Key]
        public int Id { get; set; }

        //[StringLength(50)]
        //public string Name { get; set; }

        //[StringLength(250)]
        //public string Notes { get; set; }
    }
}

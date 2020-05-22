﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendLab.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Name{ get; set; }
        [Required]
        public string Speciality { get; set; }
    }
}

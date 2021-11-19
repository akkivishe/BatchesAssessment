﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BatchAssessment.Models
{
    
    public class Attribute
    {
        public int Id { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string  Value { get; set; }
        //public Guid BatchId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BatchAssessment.Models
{
    public class Batch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BatchId { get; set; }


        [Required]
        [Display(Name = "BusinessUnit")]
        public string BusinessUnit{ get; set; }

        public IEnumerable<Attribute> Attributes { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}

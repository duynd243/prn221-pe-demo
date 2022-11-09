using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CandidateManagement.DataAccess.Models
{
    public partial class CandidateProfile
    {
        [Required]
        public string CandidateId { get; set; }
        [Required]
        [MinLength(12)]
        public string Fullname { get; set; }
        [Required]
        public DateTime? Birthday { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 12)]
        public string ProfileShortDescription { get; set; }
        [Required]
        public string ProfileUrl { get; set; }
        [Required]
        public string PostingId { get; set; }

        public virtual JobPosting Posting { get; set; }
    }
}

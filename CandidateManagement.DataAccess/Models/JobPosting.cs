using System;
using System.Collections.Generic;

#nullable disable

namespace CandidateManagement.DataAccess.Models
{
    public partial class JobPosting
    {
        public JobPosting()
        {
            CandidateProfiles = new HashSet<CandidateProfile>();
        }

        public string PostingId { get; set; }
        public string JobPostingTitle { get; set; }
        public string Description { get; set; }
        public DateTime? PostedDate { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; }
    }
}

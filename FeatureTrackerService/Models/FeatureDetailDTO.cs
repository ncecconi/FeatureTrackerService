using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureTrackerService.Models
{
    public class FeatureDetailDTO
    {
        public int Id { get; set; }
        public string FeatName { get; set; }
        public bool isComplete { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
    }
}
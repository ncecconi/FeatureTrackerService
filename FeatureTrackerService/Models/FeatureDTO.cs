using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeatureTrackerService.Models
{
    public class FeatureDTO
    {
        public int Id { get; set; }
        public string FeatName { get; set; }
        public bool isComplete { get; set; }
    }
}
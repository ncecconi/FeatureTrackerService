using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FeatureTrackerService.Models
{
    public class Feature
    {
        public int Id { get; set; }
        [Required]
        public string FeatName { get; set; }
        public bool isComplete { get; set; }
        public string Description { get; set; }

        // Foreign Key
        public int AuthorId { get; set; }
        // Navigation property
        public Author Author { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brewards.Models
{
    public class BreweryNewsViewModel
    {
        public int BreweryNewsViewModelId { get; set; }
        public DateTime NewsDate { get; set; }
        public ICollection<DateFeed> NewsFeed { get; set; }
    }
}
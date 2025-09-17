using System.Collections.Generic;

namespace Pagino_Teka.Models
{
    public class BookMetadata
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; } = new();
        public int Pages { get; set; }
        public double EstimatedReadTime { get; set; }
        public string Description { get; set; }
        public string Series { get; set; }
        public string Tome { get; set; }
        public string Publisher { get; set; }
        public string CoverUrl { get; set; }
        public List<string> Genres { get; set; } = new();
    }
}

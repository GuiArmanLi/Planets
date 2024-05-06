using System.ComponentModel.DataAnnotations;

namespace Planets.Data.Entities
{
    public class APODModel
    {
        [Key]
        public string Url { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string Date { get; set; }
        public string MediaType { get; set; }


    }
}
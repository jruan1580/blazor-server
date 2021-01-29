using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class SearchCatalog
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter something in to to search.")]
        public string Value { get; set; }
        public string SearchBy { get; set; }
    }
}

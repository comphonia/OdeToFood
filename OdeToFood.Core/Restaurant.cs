using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, StringLength(80, MinimumLength = 5)]
        public string Name { get; set; }

        [Required, StringLength(80, MinimumLength = 5, ErrorMessage = "Location must be between 5 and 255 characters long")]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}

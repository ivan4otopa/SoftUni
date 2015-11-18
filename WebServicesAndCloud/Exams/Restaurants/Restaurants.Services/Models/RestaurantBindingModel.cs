namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RestaurantBindingModel
    {
        [Required]
        public string Name { get; set; }

        public int TownId { get; set; }
    }
}
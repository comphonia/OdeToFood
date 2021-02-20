using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int id)
        {
            Restaurant = restaurantData.GetRestaurantById(id);
            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            var restaurant = restaurantData.DeleteRestaurant(id);
            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            TempData["Message"] = $"{restaurant.Name} had been deleted!";
            return RedirectToPage("./List");
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Customers
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Customer Customer { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            Customer = restaurantData.GetCustomerById(id);

            if (Customer == null)
                return RedirectToPage("./NotFound");

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;

namespace OdeToFood.Pages.Customers
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            Customers = restaurantData.GetCustomersByName(SearchTerm);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? id)
        {

            Cuisines = htmlHelper
                .GetEnumSelectList<CuisineType>()
                .OrderBy(c => c.Text != Enum.GetName(typeof(CuisineType), CuisineType.None))
                .ThenBy(c => c.Text);

            Restaurant = id.HasValue ? restaurantData.GetRestaurantById(id.Value) : new Restaurant();
            if (Restaurant == null) return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper
                    .GetEnumSelectList<CuisineType>()
                    .OrderBy(c => c.Text != Enum.GetName(typeof(CuisineType), CuisineType.None))
                    .ThenBy(c => c.Text);

                return Page();
            }

            if (Restaurant.Id > 0)
            {
                restaurantData.UpdateRestaurant(Restaurant);
            }
            else
            {
                restaurantData.AddRestaurant(Restaurant);
            }

            restaurantData.Commit();
            TempData["Message"] = "Restaurant Created!";
            return RedirectToPage("./Detail", new { id = Restaurant.Id });

        }
    }


}
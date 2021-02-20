using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbContext context;

        public RestaurantsController(OdeToFoodDbContext context)
        {
            this.context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestaurants()
        {
            return await context.Restaurants.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")] 
        public async Task<ActionResult<Restaurant>> GetRestaurant(int id)
        {
            var restaurant = await context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Restaurants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Restaurant>> DeleteRestaurant(int id)
        {
            var restaurant = await context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            context.Restaurants.Remove(restaurant);
            await context.SaveChangesAsync();

            return restaurant;
        }

        private bool RestaurantExists(int id)
        {
            return context.Restaurants.Any(e => e.Id == id);
        }
    }
}

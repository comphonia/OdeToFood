using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant AddRestaurant(Restaurant newRestaurant);
        Restaurant DeleteRestaurant(int id);
        int Commit();
        IEnumerable<Customer> GetCustomersByName(string name);
        Customer GetCustomerById(int id);
    }
}

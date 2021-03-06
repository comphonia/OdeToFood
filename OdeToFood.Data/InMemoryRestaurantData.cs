﻿using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;
        private readonly List<Customer> customers;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 3, Name = "Beignets", Location = "New Orleans", Cuisine = CuisineType.French},
                new Restaurant {Id = 2, Name = "La Costa", Location = "California", Cuisine = CuisineType.Mexican},
            };

            customers = new List<Customer>()
            {
                new Customer{CustomerId = 1, FirstName = "John", LastName = "Doe", PhoneNumber = "405-335-0000"},
                new Customer{CustomerId = 2, FirstName = "Alice", LastName = "Jack", PhoneNumber = "308-335-0000"},
                new Customer{CustomerId = 3, FirstName = "Mark", LastName = "Lue", PhoneNumber = "205-335-0000"},
            };

        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants.Where(r => string.IsNullOrEmpty(name) || r.Name.ToLower().StartsWith(name.ToLower()));
        }

        public Restaurant GetRestaurantById(int id)
        {

            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public int GetRestaurantCount()
        {
            return restaurants.Count();
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Customer> GetCustomersByName(string name = null)
        {
            return customers.Where(c => string.IsNullOrEmpty(name) || c.FirstName.ToLower().StartsWith(name));
        }

        public Customer GetCustomerById(int id)
        {
            return customers.Find(c => c.CustomerId == id);
        }

    }
}
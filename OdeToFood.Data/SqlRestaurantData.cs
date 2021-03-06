﻿using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = dbContext.Restaurants
                .Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(r => r.Name);
            return query;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return dbContext.Restaurants.Find(id);
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = dbContext.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant AddRestaurant(Restaurant newRestaurant)
        {
            dbContext.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
                dbContext.Restaurants.Remove(restaurant);

            return restaurant;
        }

        public int GetRestaurantCount()
        {
            return dbContext.Restaurants.Count();
        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            var query = dbContext.Customers
                .Where(c => c.FirstName.StartsWith(name) || string.IsNullOrEmpty(name))
                .OrderBy(c => c.FirstName).Select(e => e);
            return query;
        }

        public Customer GetCustomerById(int id)
        {
            return dbContext.Customers.Find(id);
        }
    }
}
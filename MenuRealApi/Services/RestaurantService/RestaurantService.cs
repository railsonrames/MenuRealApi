using MenuRealApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MenuRealApi.Services.RestaurantService
{
    public class RestaurantService : IRestaurantService
    {
        private static Dictionary<DayOfWeek, string> workHours = new()
        {
            { DayOfWeek.Monday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { DayOfWeek.Tuesday, "Fechado" },
            { DayOfWeek.Wednesday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { DayOfWeek.Thursday, "Fechado" },
            { DayOfWeek.Friday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { DayOfWeek.Saturday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { DayOfWeek.Sunday, "11:30 ~ 14:30|19:30 ~ 21:30" },
        };

        private static List<Restaurant> restaurantList = new()
        {
            new Restaurant
            {
                Id = Guid.NewGuid(),
                Name = "Casa das Sandes",
                Buffet = false,
                Category = new Category { Id = 1, Name = "Portuguesa", IsActive = true, Order = 1 },
                PriceStar = 2,
                Description = "Diárias, sandes e bifanas.",
                TakeAway = true,
                Address = new Address { Id = Guid.NewGuid(), City = "Ponte de Sor", Number = "63", Country = Country.Portugal, PostalCode = "7400-145", Street = "Avenida da Liberdade" },
                CreatedAt = DateTime.Now,
                WorkHours = workHours
            },
            new Restaurant
            {
                Id = Guid.NewGuid(),
                Name = "Petisqueira Alentejana",
                Buffet = false,
                Category = new Category { Id = 1, Name = "Portuguesa", IsActive = true, Order = 2 },
                PriceStar = 4,
                Description = "Diárias, sandes e petiscos.",
                TakeAway = true,
                Address = new Address { Id = Guid.NewGuid(), City = "Ponte de Sor", Number = "12", Country = Country.Portugal, PostalCode = "7400-145", Street = "Rua Luiz de Camões" },
                CreatedAt = DateTime.Now,
                WorkHours = workHours
            },
        };

        public List<Restaurant> Create(Restaurant request)
        {
            request.CreatedAt = DateTime.Now;
            request.UpdatedAt = null;
            restaurantList.Add(request);
            return restaurantList;
        }

        public List<Restaurant> Delete(Guid id)
        {
            var restaurant = restaurantList.Find(x => x.Id == id);
            if (restaurant is null)
                return null;

            restaurantList.Remove(restaurant);
            return restaurantList;
        }

        public Restaurant Get(Guid id)
        {
            var restaurant = restaurantList.Find(x => x.Id == id);
            return restaurant;
        }

        public List<Restaurant> GetAll()
        {
            return restaurantList;
        }

        public Restaurant Update(Guid id, Restaurant request)
        {
            var restaurant = restaurantList.Find(x => x.Id == id);
            if (restaurant is null)
            {
                return restaurant;
            }

            restaurant.Name = request.Name;
            restaurant.PriceStar = request.PriceStar;
            restaurant.Address = request.Address;
            restaurant.Buffet = request.Buffet;
            restaurant.Category = request.Category;
            restaurant.Description = request.Description;
            restaurant.UpdatedAt = DateTime.Now;
            restaurant.TakeAway = request.TakeAway;
            restaurant.WorkHours = request.WorkHours;

            return restaurant;
        }
    }
}

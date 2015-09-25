﻿namespace Restaurants.Services.Models
{
    using Restaurants.Models;
    using System;
    using System.Linq.Expressions;

    public class MealViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Type { get; set; }

        public static Expression<Func<Meal, MealViewModel>> Create
        {
            get
            {
                return m => new MealViewModel()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Price = m.Price,
                    Type = m.Type.Name
                };
            }
        }
    }
}
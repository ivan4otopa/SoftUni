namespace Restaurants.Services.Models
{
    using Restaurants.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class RestaurantViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Rating { get; set; }

        public TownViewModel Town { get; set; }

        public static Expression<Func<Restaurant, RestaurantViewModel>> Create
        {
            get
            {
                return r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Rating = r.Ratings.Count == 0 ? 0 : r.Ratings.Average(ra => ra.Stars),
                    Town = new TownViewModel()
                    {
                        Id = r.TownId,
                        Name = r.Town.Name
                    }
                };
            }
        }
    }
}
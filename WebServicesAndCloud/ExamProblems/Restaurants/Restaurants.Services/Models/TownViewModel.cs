namespace Restaurants.Services.Models
{
    using Restaurants.Models;
    using System;
    using System.Linq.Expressions;

    public class TownViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Town, TownViewModel>> Create
        {
            get
            {
                return t => new TownViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                };
            }
        }
    }
}
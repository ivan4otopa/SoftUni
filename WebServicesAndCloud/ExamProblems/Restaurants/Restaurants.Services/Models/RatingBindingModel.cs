﻿namespace Restaurants.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RatingBindingModel
    {
        [Range(1, 10)]
        public int Stars { get; set; }
    }
}
﻿namespace Twitter.MVC.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class UserBindingModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
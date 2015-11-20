namespace SportSystem.App.Models.BindingModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class TeamBindingModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required.")]
        public string Name { get; set; }

        [DisplayName("Nickname")]
        public string NickName { get; set; }
        
        public string Website { get; set; }

        [DisplayName("Founded")]
        public DateTime DateFounded { get; set; }

        public List<string> Players { get; set; }
    }
}
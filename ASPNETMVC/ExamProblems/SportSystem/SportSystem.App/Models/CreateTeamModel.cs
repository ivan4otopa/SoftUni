namespace SportSystem.App.Models
{
    using BindingModels;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Web.Mvc;

    public class CreateTeamModel
    {
        public TeamBindingModel TeamBindingModel { get; set; }

        [DisplayName("Player")]
        public IEnumerable<SelectListItem> Players { get; set; }
    }
}
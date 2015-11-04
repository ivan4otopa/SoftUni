namespace SportSystem.App.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class PlayerBindingModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} is required.")]
        public string Name { get; set; }
    }
}
namespace News.Models
{
    using System.ComponentModel.DataAnnotations;

    public class NewsEntity
    {
        public int Id { get; set; }

        [ConcurrencyCheck]
        public string Content { get; set; }
    }
}

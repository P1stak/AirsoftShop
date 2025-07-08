using System.ComponentModel.DataAnnotations;

namespace AirsoftShop.Models
{
    public class Product
    {
        private static int instanceCounter = 1;
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Cost { get; set; }
        [Required]
        public string Descriprion { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public Product()
        {
            Id = instanceCounter;
            instanceCounter += 1;
        }

        public Product(string name, decimal cost, string descriprion, string imageUrl) : this()
        {
            Name = name;
            Cost = cost;
            Descriprion = descriprion;
            ImageUrl = imageUrl;
        }
    }
}

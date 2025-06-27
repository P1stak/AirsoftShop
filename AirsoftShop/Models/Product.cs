namespace AirsoftShop.Models
{
    public class Product
    {
        private static int instanceCounter = 1;
        public int Id { get;  }
        public string Name { get; }
        public decimal Cost { get; }
        public string Descriprion { get; }
        public string ImageUrl { get; }

        public Product(string name, decimal cost, string descriprion, string imageUrl)
        {
            Id = instanceCounter;
            Name = name;
            Cost = cost;
            Descriprion = descriprion;
            ImageUrl = imageUrl;

            instanceCounter += 1;
        }
    }
}

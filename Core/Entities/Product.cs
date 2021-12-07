using Core.Contracts;

namespace Core.Entities
{
    public class Product : IClient
    {
        public Product(string name, string description, int rate)
        {
            Name = name;
            Description = description;
            Rate = rate;
        }

        protected Product()
        {
        }

        public int ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Rate { get; private set; }
        public string ClientId { get; set; }
    }
}
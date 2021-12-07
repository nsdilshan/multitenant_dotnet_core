using Core.Options;

namespace Core.Interfaces
{
    public interface IClientService
    {
        public string GetConnectionString();

        public Client GetClient();
    }
}
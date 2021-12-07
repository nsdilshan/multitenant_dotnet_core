using Core.Contracts;

namespace Core.Entities
{
    public class User : IClient
    {
        public User(string userName, string email)
        {
            UserName = userName;
            Email = email;
        }

        protected User()
        {
        }

        public int UserId { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string ClientId { get; set; }
    }
}
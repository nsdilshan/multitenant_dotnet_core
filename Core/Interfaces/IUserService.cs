using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(string userName, string email);

        Task<User> GetByIdAsync(int id);

        Task<IReadOnlyList<User>> GetAllAsync();
    }
}
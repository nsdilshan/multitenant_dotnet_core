using Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBranchService
    {
        Task<Branch> CreateAsync(string userName, string email);

        Task<Branch> GetByIdAsync(int id);

        Task<IReadOnlyList<Branch>> GetAllAsync();
    }
}
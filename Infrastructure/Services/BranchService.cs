using Core.Entities;
using Core.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BranchService : IBranchService
    {
        private readonly ClientDbContext _context;

        public BranchService(ClientDbContext context)
        {
            _context = context;
        }

        public async Task<Branch> CreateAsync(string branchName, string location)
        {
            var branch = new Branch(branchName, location);
            _context.Branches.Add(branch);
            await _context.SaveChangesAsync();
            return branch;
        }

        public async Task<IReadOnlyList<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _context.Branches.FindAsync(id);
        }

    }
}
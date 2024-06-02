using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kiseleva.GraduationProject.Repository
{
    public class OrganisationRepository : IOrganisationRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganisationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Organisation organisation)
        {
            _context.Add(organisation);
            return Save();
        }

        public bool Delete(Organisation organisation)
        {
            _context.Remove(organisation);
            return Save();
        }

        public async Task<IEnumerable<Organisation>> GetAllOrganisationsAsync()
        {
            return await _context.Organisations.ToListAsync();
        }

        public async Task<Organisation> GetByIdAsync(int id)
        {
            return await _context.Organisations
                .Include(o => o.Person)
                .Include(o => o.Addresses)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Organisation> GetByIdForRemovingAsync(int id)
        {
            return await _context.Organisations
                .Include(p => p.Addresses)
                .Include(p => p.Contract)
                .Include(o => o.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Organisations.CountAsync();
        }

        public async Task<IEnumerable<Organisation>> GetSliceAsync(int offset, int size)
        {
            return await _context.Organisations.Skip(offset).Take(size).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Organisation organisation)
        {
            _context.Update(organisation);
            return Save();
        }
    }
}

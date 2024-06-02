using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kiseleva.GraduationProject.Repository
{
    public class CZNRepository : ICZNRepository
	{
        private readonly ApplicationDbContext _context;

        public CZNRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(CZN CZN)
        {
            _context.Add(CZN);
            return Save();
        }

        public bool Delete(CZN CZN)
        {
            _context.Remove(CZN);
            return Save();
        }

        public async Task<IEnumerable<CZN>> GetAllCZNsAsync()
        {
            return await _context.CZNs.ToListAsync();
        }

        public async Task<CZN> GetByIdAsync(int id)
        {
            return await _context.CZNs
                .Include(c => c.Person)
                .Include(c => c.Addresses)
                .Include(c => c.Files)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<CZN> GetByIdForRemovingAsync(int id)
        {
            return await _context.CZNs
                .Include(p => p.Files)
				.Include(p => p.Addresses)
                .Include(o => o.Person)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.CZNs.CountAsync();
        }

        public async Task<IEnumerable<CZN>> GetSliceAsync(int offset, int size)
        {
            return await _context.CZNs.Skip(offset).Take(size).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(CZN CZN)
        {
            _context.Update(CZN);
            return Save();
        }
    }
}

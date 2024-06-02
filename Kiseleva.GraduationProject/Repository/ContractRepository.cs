using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kiseleva.GraduationProject.Repository
{
    public class ContractRepository : IContractRepository
    {
        private readonly ApplicationDbContext _context;

        public ContractRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Contract contract)
        {
            _context.Add(contract);
            return Save();
        }

        public bool Delete(Contract contract)
        {
            _context.Remove(contract);
            return Save();
        }

        public async Task<Contract> GetByIdAsync(int id)
        {
            return await _context.Contract
                .Include(d => d.Person)
                .Include(d => d.Person.Address)
                .Include(d => d.Person.DocumentsOfPerson)
                .Include(d => d.ProgramOfEducation)
                .FirstOrDefaultAsync(d => d.Id == id);      
        }

        public async Task<Contract> GetByIdAsyncForOrganisation(int id)
        {
            return await _context.Contract
                .Include(d => d.Organisation)
                .Include(d => d.Organisation.Addresses)
                .Include(d => d.Organisation.Person)
                .Include(d => d.ProgramOfEducation)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}

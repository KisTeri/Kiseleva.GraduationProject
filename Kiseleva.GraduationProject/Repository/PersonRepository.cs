using Kiseleva.GraduationProject.Data;
using Kiseleva.GraduationProject.Entities;
using Kiseleva.GraduationProject.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kiseleva.GraduationProject.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;

        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(DocumentOfPerson documentOfPerson)
        {
            _context.Add(documentOfPerson);
            return Save();
        }

        public bool Delete(Person person)
        {
            _context.Remove(person);
            return Save();
        }

        public async Task<IEnumerable<Person>> GetAllPersonsAsync()
        {
            return await _context.Persons.Where(p => p.KindOfPerson.ToLower() == "ученик").ToListAsync();
     
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.Persons
                .Include(p => p.Address)
                .Include(p => p.DocumentsOfPerson)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> GetByIdForRemovingAsync(int id)
        {
            return await _context.Persons
                .Include(p => p.Files)
                .Include(p => p.Address)
                .Include(p => p.DocumentsOfPerson)
                .Include(p => p.Contracts)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Persons.CountAsync();
        }

        public async Task<IEnumerable<Person>> GetSliceAsync(int offset, int size)
        {
            return await _context.Persons.Skip(offset).Take(size).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Person person)
        {
            _context.Update(person); 
            return Save();
        }
    }
}

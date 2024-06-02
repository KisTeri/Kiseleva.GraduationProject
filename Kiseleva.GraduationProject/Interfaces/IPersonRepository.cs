using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAllPersonsAsync();
        Task<Person> GetByIdAsync(int id);
        Task<Person> GetByIdForRemovingAsync(int id);
        bool Add(DocumentOfPerson documentOfPerson);
        bool Update(Person person);
        bool Delete(Person person);
        bool Save();
        Task<IEnumerable<Person>> GetSliceAsync(int offset, int size);
        Task<int> GetCountAsync();
    }
}

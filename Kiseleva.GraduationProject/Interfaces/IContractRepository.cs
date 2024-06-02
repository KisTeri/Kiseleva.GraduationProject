using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Interfaces
{
    public interface IContractRepository
    {
        //Task<IEnumerable<Person>> GetAllPersonsAsync(); пока не надо
        Task<Contract> GetByIdAsync(int id);
        Task<Contract> GetByIdAsyncForOrganisation(int id);
        bool Add(Contract contract);
        //bool Update(Contract contract); не уверена
        bool Delete(Contract contract);
        bool Save();
    }
}

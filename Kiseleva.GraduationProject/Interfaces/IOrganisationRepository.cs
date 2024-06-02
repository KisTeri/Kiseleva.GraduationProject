using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Interfaces
{
    public interface IOrganisationRepository
    {
        Task<IEnumerable<Organisation>> GetAllOrganisationsAsync();
        Task<Organisation> GetByIdAsync(int id);
        Task<Organisation> GetByIdForRemovingAsync(int id);
        bool Add(Organisation organisation);
        bool Update(Organisation organisation);
        bool Delete(Organisation organisation);
        bool Save();
        Task<IEnumerable<Organisation>> GetSliceAsync(int offset, int size);
        Task<int> GetCountAsync();
    }
}

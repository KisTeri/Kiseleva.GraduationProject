using Kiseleva.GraduationProject.Entities;

namespace Kiseleva.GraduationProject.Interfaces
{
    public interface ICZNRepository
	{
        Task<IEnumerable<CZN>> GetAllCZNsAsync();
        Task<CZN> GetByIdAsync(int id);
        Task<CZN> GetByIdForRemovingAsync(int id);
        bool Add(CZN CZN);
        bool Update(CZN CZN);
        bool Delete(CZN CZN);
        bool Save();
        Task<IEnumerable<CZN>> GetSliceAsync(int offset, int size);
        Task<int> GetCountAsync();
    }
}

using SDI_App.Models;

namespace SDI_App.Repository.Interfaces
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        public Task<Person?> GetPersonByCNP(string cnp);
        public Task<bool> PersonExists(int id);
    }
}
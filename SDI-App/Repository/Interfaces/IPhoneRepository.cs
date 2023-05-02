using SDI_App.Models;

namespace SDI_App.Repository.Interfaces
{
    public interface IPhoneRepository : IGenericRepository<Phone>
    {
        public Task<Phone?> GetPhoneByModelNumber(int modelNumber);
        public Task<bool> PhoneExists(int id);
    }
}
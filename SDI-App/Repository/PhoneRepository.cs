using Microsoft.EntityFrameworkCore;
using SDI_App.Data;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Repository
{
    public class PhoneRepository : GenericRepository<Phone>, IPhoneRepository
    {
        private readonly DataContext _context;
        public PhoneRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<Phone?> GetPhoneByModelNumber(int modelNumber)
        {
            return _context.Phones.FirstOrDefaultAsync(p => p.ModelNumber == modelNumber);
        }

        public Task<bool> PhoneExists(int modelNumber)
        {
            return _context.Phones.AnyAsync(p => p.ModelNumber == modelNumber);
        }
    }
}
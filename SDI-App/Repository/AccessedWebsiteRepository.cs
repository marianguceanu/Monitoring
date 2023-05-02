using Microsoft.EntityFrameworkCore;
using SDI_App.Data;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Repository
{
    public class AccessedWebsiteRepository : GenericRepository<AccessedWebsite>, IAccessedWebsiteRepository
    {
        private readonly DataContext _context;
        public AccessedWebsiteRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AccessedWebsiteExists(string url)
        {
            return await _context.AccessedWebsites.AnyAsync(aw => aw.Url.Contains(url));
        }

        public async Task<AccessedWebsite?> GetAccessedWebsiteByUrl(string url)
        {
            return await _context.AccessedWebsites.FirstOrDefaultAsync(aw => aw.Url == url);
        }
    }

}
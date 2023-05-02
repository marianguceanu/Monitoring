using Microsoft.EntityFrameworkCore;
using SDI_App.Data;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Repository
{
    public class TabletRepository : GenericRepository<Tablet>, ITabletRepository
    {
        private readonly DataContext _context;
        public TabletRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<Tablet?> GetTabletByUnitsSold(int UnitsSold)
        {
            return _context.Tablets.FirstOrDefaultAsync(t => t.UnitsSold == UnitsSold);
        }

        public Task<bool> TabletExists(int UnitsSold)
        {
            return _context.Tablets.AnyAsync(t => t.UnitsSold == UnitsSold);
        }
    }
}
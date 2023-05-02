using SDI_App.Models;

namespace SDI_App.Repository.Interfaces
{
    public interface ITabletRepository : IGenericRepository<Tablet>
    {
        public Task<Tablet?> GetTabletByUnitsSold(int UnitsSold);
        public Task<bool> TabletExists(int UnitsSold);
    }
}
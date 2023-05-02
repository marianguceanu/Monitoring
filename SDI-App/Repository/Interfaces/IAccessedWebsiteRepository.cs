using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDI_App.Models;

namespace SDI_App.Repository.Interfaces
{
    public interface IAccessedWebsiteRepository : IGenericRepository<AccessedWebsite>
    {
        public Task<AccessedWebsite?> GetAccessedWebsiteByUrl(string url);
        public Task<bool> AccessedWebsiteExists(string url);
    }
}
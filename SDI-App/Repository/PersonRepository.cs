using Microsoft.EntityFrameworkCore;
using SDI_App.Data;
using SDI_App.Models;
using SDI_App.Repository.Interfaces;

namespace SDI_App.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly DataContext _context;
        public PersonRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public Task<Person?> GetPersonByCNP(string cnp)
        {
            return _context.Persons.FirstOrDefaultAsync(p => p.CNP.Equals(cnp));
        }

        public Task<bool> PersonExists(int id)
        {
            return _context.Persons.AnyAsync(p => p.Id == id);
        }
    }
}
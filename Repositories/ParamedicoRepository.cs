using Microsoft.EntityFrameworkCore;
using SIGEApi.Data;

namespace SIGEApi.Repositories
{
    public class ParamedicoRepository
    {
        private readonly AppDbContext _context;

        public ParamedicoRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}

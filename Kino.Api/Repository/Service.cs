using Kino.Api.DataLayer;
using Kino.Api.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Api.Repository
{
    public class Service : IService
    {
        private readonly KinoDbContext _kinoDb;

        public Service(KinoDbContext kinoDb)
        {
            _kinoDb = kinoDb;
            
        }

        public async Task<IEnumerable<Moveis>> GetAllMoveisAsync()
        {
            var res =  await _kinoDb.Moveiss.ToListAsync();
            if (res == null)
            {
                return null;
            }
            return res;
        }
    }
}

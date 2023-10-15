using Kino.Api.DataLayer;
using Kino.Api.Model;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Api.Repository
{
    public class Service : IService
    {
        private readonly KinoDbContext _kinoDb;
        private readonly IWebHostEnvironment _web;

        public Service(IWebHostEnvironment web,KinoDbContext kinoDb)
        {
            _kinoDb = kinoDb;
            _web = web;
            
        }

        public async Task<Moveis> AddMoveisAsync(Moveis moveis)
        {
            if (moveis == null)
            {
                return new Moveis();
            }
            await _kinoDb.AddAsync(moveis);
            await _kinoDb.SaveChangesAsync();
            return moveis;

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
            
        public async Task<Moveis> GetByIdMoveisAsync(int moveisId)
        {
            var moveis = await _kinoDb.Moveiss.FirstOrDefaultAsync(p => p.Id == moveisId);
            return moveis;
        }

        public async Task<Moveis> SetImageAsync(int moveisId, IFormFile file)
        {
             var movie = await _kinoDb.Moveiss.FirstOrDefaultAsync(p => p.Id == moveisId);

             string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
             string path = Path.Combine(_web.WebRootPath, $"Image/{fileName}");


             FileStream fileStream = File.Open(path,FileMode.Create);
             await file.OpenReadStream().CopyToAsync(fileStream);

            fileStream.Flush();
            fileStream.Close();
            movie.Image = fileName;
            return movie;





         }
    }
}

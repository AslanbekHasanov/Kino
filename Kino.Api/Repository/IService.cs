using Kino.Api.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Kino.Api.Repository
{
    public interface IService
    {
        Task<Moveis> SetImageAsync(int moveisId, IFormFile file);
        Task<Moveis> GetByIdMoveisAsync(int moveisId);
        Task<Moveis> AddMoveisAsync(Moveis moveis);
        Task<IEnumerable<Moveis>> GetAllMoveisAsync();
    }
}

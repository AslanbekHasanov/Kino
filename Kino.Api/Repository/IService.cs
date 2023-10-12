using Kino.Api.Model;
using System.Collections.Generic;

namespace Kino.Api.Repository
{
    public interface IService
    {
        Task<IEnumerable<Moveis>> GetAllMoveisAsync();
    }
}

using System;
using System.Threading.Tasks;
using LanguageExt;
using RouletteService.Services.Data;

namespace RouletteService.Services
{
    public interface IPlayerService
    {
        Task<Either<Exception, Identifier>> Create(CreatePlayer createPlayer);
    }
}
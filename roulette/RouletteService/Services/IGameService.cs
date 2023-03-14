using System;
using System.Threading.Tasks;
using LanguageExt;
using RouletteService.Services.Data;
using RData = RouletteService.Repositories.Data;

namespace RouletteService.Services
{
    public interface IGameService
    {
        Task<Option<RData.Game>> Get(int id);
        Task<Either<Exception, Identifier>> Create(CreateGame createGame);
    }
}
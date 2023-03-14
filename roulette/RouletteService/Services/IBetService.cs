using System;
using System.Threading.Tasks;
using LanguageExt;
using RouletteService.Services.Data;

namespace RouletteService.Services
{
    public interface IBetService
    {
        Task<Either<Exception, Identifier>> Create(CreateBet createBet);
    }
}
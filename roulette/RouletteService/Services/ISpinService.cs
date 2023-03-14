using System;
using System.Threading.Tasks;
using LanguageExt;
using RouletteService.Services.Data;

namespace RouletteService.Services
{
    public interface ISpinService
    {
        Task<Either<Exception, Identifier>> Create(CreateSpin createSpin);
    }
}
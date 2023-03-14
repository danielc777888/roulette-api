using RouletteService.Repositories;
using RData = RouletteService.Repositories.Data;
using RouletteService.Services.Data;
using System;
using System.Threading.Tasks;
using LanguageExt;

namespace RouletteService.Services
{
    public class SpinService : ISpinService
    {
        private readonly ISpinRepository spinRepository;

        public SpinService(ISpinRepository spinRepository)
        {
            this.spinRepository = spinRepository;
        }


        public async Task<Either<Exception, Identifier>> Create(CreateSpin createSpin)
        {
            var result = Core.Spin.Create(createSpin);

            if (result.IsLeft)
            {
                return Either<Exception, Identifier>.Left(((Exception)result));
            }
            //TODO: get players, update balance, all in one enclosing txn
            var id = await spinRepository.Insert(((RData.Spin)result));
            return Either<Exception, Identifier>.Right(new Identifier { Id = id });
        }
    }
}

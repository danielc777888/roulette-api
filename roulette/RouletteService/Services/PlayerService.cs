using RouletteService.Repositories;
using RData = RouletteService.Repositories.Data;
using RouletteService.Services.Data;
using System;
using System.Threading.Tasks;
using LanguageExt;

namespace RouletteService.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        public async Task<Either<Exception, Identifier>> Create(CreatePlayer createPlayer)
        {
            var result = Core.Player.Create(createPlayer);

            if (result.IsLeft)
            {
                return Either<Exception, Identifier>.Left(((Exception)result));
            }
            var id = await playerRepository.Insert(((RData.Player)result));
            return Either<Exception, Identifier>.Right(new Identifier { Id = id });
        }
    }
}

using RouletteService.Repositories;
using RData = RouletteService.Repositories.Data;
using RouletteService.Services.Data;
using System;
using System.Threading.Tasks;
using LanguageExt;

namespace RouletteService.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        public async Task<Option<RData.Game>> Get(int id)
        {
            var result = await gameRepository.Get(id);
            return result.HeadOrNone<RData.Game>();
        }


        public async Task<Either<Exception, Identifier>> Create(CreateGame createGame)
        {
            var result = Core.Game.Create(createGame);

            if (result.IsLeft)
            {
                return Either<Exception, Identifier>.Left(((Exception)result));
            }
            var id = await gameRepository.Insert(((RData.Game)result));
            return Either<Exception, Identifier>.Right(new Identifier { Id = id });
        }
    }
}

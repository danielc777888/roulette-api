// spin related functions


using RouletteService.Services.Data;
using RData = RouletteService.Repositories.Data;
using System;
using LanguageExt;


namespace RouletteService.Core
{
    public static class Spin
    {
        public static Either<Exception, RData.Spin> Create(CreateSpin createSpin)
        {
            if (createSpin.Number < 0 || createSpin.Number > 36)
            {
                return Either<Exception, RData.Spin>.Left(new Exception("Number must be between 1 and 36"));
            }
            var spin = new RData.Spin
            {
                Number = createSpin.Number,
                GameId = createSpin.GameId
            };

            return Either<Exception, RData.Spin>.Right(spin);

        }

    }


}
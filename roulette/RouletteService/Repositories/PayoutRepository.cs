using Dapper;
using LanguageExt;
using Microsoft.Data.Sqlite;
using RouletteService.Database;
using RouletteService.Repositories.Data;
using System;
using System.Threading.Tasks;

namespace RouletteService.Repositories
{
    public class PayoutRepository : IPayoutRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public PayoutRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<int> Insert(Payout payout)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO payout (amount, gameId, playerId, created_at)
                VALUES (@Amount, @GameId, @PlayerId, datetime()); select last_insert_rowid();", payout);
            return id;
        }


    }
}

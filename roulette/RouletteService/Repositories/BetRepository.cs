using Dapper;
using Microsoft.Data.Sqlite;
using RouletteService.Database;
using RouletteService.Repositories.Data;
using System.Threading.Tasks;

namespace RouletteService.Repositories
{
    public class BetRepository : IBetRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public BetRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<int> Insert(Bet bet)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO bet (amount, type, number, player_id, game_id, created_at)
                VALUES (@Amount, @Type, @Number, @PlayerId, @GameId, datetime()); select last_insert_rowid();", bet);
            return id;
        }


    }
}

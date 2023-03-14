using Dapper;
using Microsoft.Data.Sqlite;
using RouletteService.Database;
using RouletteService.Repositories.Data;
using System.Threading.Tasks;

namespace RouletteService.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public PlayerRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<int> Insert(Player player)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO player (name, balance)
                VALUES (@Name, @Balance); select last_insert_rowid();", player);
            return id;
        }


    }
}

using Dapper;
using Microsoft.Data.Sqlite;
using RouletteService.Database;
using RouletteService.Repositories.Data;
using System.Threading.Tasks;

namespace RouletteService.Repositories
{
    public class SpinRepository : ISpinRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public SpinRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<int> Insert(Spin spin)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO spin (number, game_id, created_at)
                VALUES (@Number, @GameId, datetime()); select last_insert_rowid();", spin);
            return id;
        }

    }
}

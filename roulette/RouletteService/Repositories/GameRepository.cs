using Dapper;
using LanguageExt;
using Microsoft.Data.Sqlite;
using RouletteService.Database;
using RouletteService.Repositories.Data;
using System;
using System.Threading.Tasks;

namespace RouletteService.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public GameRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<int> Insert(Game game)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var id = await connection.QuerySingleAsync<int>(@"INSERT INTO game (min_bet, created_at)
                VALUES (@MinBet, datetime()); select last_insert_rowid();", game);
            return id;
        }

        public async Task<Option<Game>> Get(int id)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            try
            {
                var game = await connection.QuerySingleAsync<Game>("SELECT id AS Id, min_bet AS MinBet, created_at AS CreatedAt FROM game WHERE id = @Id;", new { Id = id });
                return Option<Game>.Some(game);
            }
            catch (Exception)
            {
                return Option<Game>.None;
            }
        }
    }
}

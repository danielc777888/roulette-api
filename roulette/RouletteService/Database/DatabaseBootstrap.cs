using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace RouletteService.Database
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var gameSql = @"
                CREATE TABLE `game` (`id` INTEGER PRIMARY KEY, min_bet INTEGER NOT NULL, created_at DATETIME NOT NULL);
                ";
            CreateTable(connection, "game", gameSql);

            var playerSql = @"
                CREATE TABLE `player` (`id` INTEGER PRIMARY KEY, name VARCHAR(255) NOT NULL, balance INTEGER NOT NULL);
                ";
            CreateTable(connection, "player", playerSql);

            var betSql = @"
                CREATE TABLE `bet` (`id` INTEGER PRIMARY KEY,
                amount INTEGER NOT NULL,
                number INTEGER NOT NULL,
                type VARCHAR(255),
                created_at DATETIME NOT NULL,
                game_id INTEGER NOT NULL,
                player_id INTEGER NOT NULL,
                FOREIGN KEY (game_id)
                    REFERENCES game (id),
                FOREIGN KEY (player_id)
                    REFERENCES player (id) );
                ";
            CreateTable(connection, "bet", betSql);

            var spinSql = @"
                CREATE TABLE `spin` (`id` INTEGER PRIMARY KEY,
                number INTEGER NOT NULL,
                created_at DATETIME NOT NULL,
                game_id INTEGER NOT NULL,
                FOREIGN KEY (game_id)
                    REFERENCES game (id));
                ";
            CreateTable(connection, "spin", spinSql);

            var payoutSql = @"
                CREATE TABLE `payout` (`id` INTEGER PRIMARY KEY,
                amount INTEGER NOT NULL,
                created_at DATETIME NOT NULL,
                game_id INTEGER NOT NULL,
                player_id INTEGER NOT NULL,
                FOREIGN KEY (game_id)
                    REFERENCES game (id),
                FOREIGN KEY (player_id)
                    REFERENCES player (id) );
                ";
            CreateTable(connection, "payout", payoutSql);
        }
        private void CreateTable(SqliteConnection connection, string name, string sql)
        {
            var table = connection.Query<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name = '{name}';");
            var tableName = table.FirstOrDefault();
            if (string.IsNullOrEmpty(tableName))
            {
                connection.Execute(sql);

            }
        }

    }
}

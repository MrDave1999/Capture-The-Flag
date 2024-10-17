﻿namespace Persistence.SQLite;

internal class TopPlayersRepository(
    ISqlCollection sqlCollection,
    SQLiteSettings sqliteSettings,
    TopPlayersSettings topPlayersSettings) : ITopPlayersRepository
{
    public IEnumerable<TopPlayersByMaxKillingSpree> GetByMaxKillingSpree(MaxTopPlayers maxPlayers)
    {
        using var connection = new SqliteConnection(sqliteSettings.ConnectionString);
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = sqlCollection["GetTopPlayersByMaxKillingSpree"];
        command.Parameters.AddWithValue("$required_max_killing_spree", topPlayersSettings.RequiredMaxKillingSpree);
        command.Parameters.AddWithValue("$max_players", maxPlayers.Value);

        using SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new TopPlayersByMaxKillingSpree
            {
                PlayerName = reader.GetString("name"),
                MaxKillingSpree = reader.GetInt32("max_killing_spree")
            };
        }
    }

    public IEnumerable<TopPlayersByTotalKills> GetByTotalKills(MaxTopPlayers maxPlayers)
    {
        using var connection = new SqliteConnection(sqliteSettings.ConnectionString);
        connection.Open();

        SqliteCommand command = connection.CreateCommand();
        command.CommandText = sqlCollection["GetTopPlayersByTotalKills"];
        command.Parameters.AddWithValue("$required_total_kills", topPlayersSettings.RequiredTotalKills);
        command.Parameters.AddWithValue("$max_players", maxPlayers.Value);

        using SqliteDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            yield return new TopPlayersByTotalKills
            {
                PlayerName = reader.GetString("name"),
                TotalKills = reader.GetInt32("total_kills"),
                Rank = (RankId)reader.GetInt32("rank_id")
            };
        }
    }
}

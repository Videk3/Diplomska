using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska
{
    class Database
    {
        NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres;" + "Password=postgres; Database=diplomska_db;");
        void Connect()
        {
            using (con)
            {
                con.Open();
            }
        }
        void Disconnect()
        {
            using (con)
            {
                con.Close();
            }
        }
        public void AddMatch(string champion, string role, string summoner_spell1, string summoner_spell2, DateTime date, int kills, int deaths, int assists, int creep_score, int vision_score, int match_lenght, int drake, int rift_herald, int baron, string enemy_top, string enemy_jungle, string enemy_mid, string enemy_adc, string enemy_support)
        {
            int enemy_team_id = AddEnemyTeam(enemy_top, enemy_jungle, enemy_mid, enemy_adc, enemy_support);
            Connect();
            NpgsqlCommand com = new NpgsqlCommand("INSERT INTO matches(date, kills, deaths, assists, creep_score, vision_score, match_lenght, drake, rift_herald, baron, summoner_spell1_id, summoner_spell2_id, champion_id, role_id, enemy_team_id)" +
                "VALUES('" + date + "', '" + kills + "', '" + deaths + "', '" + assists + "', '" + creep_score + "', '" + vision_score + "', '" + match_lenght + "', '" + drake + "', '" + rift_herald + "', '" + baron + "', '" + summoner_spell1 + "', '" + summoner_spell2 + "', '" + champion + "', '" + role + "', '" + enemy_team_id + "');", con);
            com.ExecuteNonQuery();
            Disconnect();
        }

        public int AddEnemyTeam(string enemy_top, string enemy_jungle, string enemy_mid, string enemy_adc, string enemy_support)
        {
            Connect();
            int vrni = 0;
            NpgsqlCommand com = new NpgsqlCommand("INSERT INTO enemy_team(enemy_top, enemy_jungle, enemy_mid, enemy_adc, enemy_support)" +
                               "VALUES('" + enemy_top + "', '" + enemy_jungle + "', '" + enemy_mid + "', '" + enemy_adc + "', '" + enemy_support + "')" +
                               "RETURNING enemy_team_id;", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                vrni = reader.GetInt32(0);
            }
            Disconnect();
            return vrni;
        }
    }
}

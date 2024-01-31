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
        public List<Champion> GetChampions()
        {
            List<Champion> vrni = new List<Champion>();
            Connect();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM champions;", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                vrni.Add(new Champion(reader.GetInt32(0), reader.GetString(1)));
            }
            Disconnect();
            return vrni;
        }
        public List<Role> GetRoles()
        {
            List<Role> vrni = new List<Role>();
            Connect();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM roles;", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                vrni.Add(new Role(reader.GetInt32(0), reader.GetString(1)));
            }
            Disconnect();
            return vrni;
        }
        public List<SummonerSpell> GetSummonerSpells()
        {
            List<SummonerSpell> vrni = new List<SummonerSpell>();
            Connect();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM summoner_spells;", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                vrni.Add(new SummonerSpell(reader.GetInt32(0), reader.GetString(1)));
            }
            Disconnect();
            return vrni;
        }
        public List<Match> GetMatches()
        {
            List<Match> vrni = new List<Match>();
            Connect();
            NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM matches;", con);
            NpgsqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                vrni.Add(new Match(reader.GetInt32(0), reader.GetDateTime(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6),
                    reader.GetInt32(7), reader.GetInt32(8), reader.GetInt32(9), reader.GetString(10), reader.GetString(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetInt32(15), reader.GetInt32(16)));
            }
    }
}

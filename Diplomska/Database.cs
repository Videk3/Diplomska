using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska
{
    class Database
    {
        public int AddMatch(int champion, int role, int summoner_spell1, int summoner_spell2, DateTime date, int kills, int deaths, int assists, int creep_score, int vision_score, int match_lenght, int drake, int rift_herald, int baron, string enemy_top, string enemy_jungle, string enemy_mid, string enemy_adc, string enemy_support, bool win)
        {
            int enemy_team_id = AddEnemyTeam(enemy_top, enemy_jungle, enemy_mid, enemy_adc, enemy_support);
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                int vrni = 0;
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO matches(date, kills, deaths, assists, creep_score, vision_score, match_lenght, drake, rift_herald, baron, summoner_spell1_id, summoner_spell2_id, champion_id, role_id, enemy_team_id, win)" +
                "VALUES('" + date + "', '" + kills + "', '" + deaths + "', '" + assists + "', '" + creep_score + "', '" + vision_score + "', '" + match_lenght + "', '" + drake + "', '" + rift_herald + "', '" + baron + "', '" + summoner_spell1 + "', '" + summoner_spell2 + "', '" + champion + "', '" + role + "', '" + enemy_team_id + "', '" + win + "')" +
                "RETURNING match_id;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = reader.GetInt32(0);
                }
                con.Close();
                return vrni;
            }
        }
        public int AddEnemyTeam(string enemy_top, string enemy_jungle, string enemy_mid, string enemy_adc, string enemy_support)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                int top_id = GetChampionId(enemy_top);
                int jungle_id = GetChampionId(enemy_jungle);
                int mid_id = GetChampionId(enemy_mid);
                int adc_id = GetChampionId(enemy_adc);
                int support_id = GetChampionId(enemy_support);
                con.Open();
                int vrni = 0;
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO enemy_team(top_id, jungle_id, middle_id, adc_id, support_id) " +
                "VALUES(" + top_id + ", " + jungle_id + ", " + mid_id + ", " + adc_id + ", " + support_id + ") " +
                "RETURNING enemy_team_id;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = reader.GetInt32(0);
                }
                con.Close();
                return vrni;
            }
        }
        public void AddItemToMatch(int match_id, string item)
        {
            int item_id = GetItemId(item);
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO match_items(match_id, item_id) " +
                                   "VALUES(" + match_id + ", " + item_id + ");", con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<string> GetMatchItems(int match_id)
        {
            List<string> vrni = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT item_name FROM items JOIN match_items ON items.item_id = match_items.item_id WHERE match_items.match_id = " + match_id + ";", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni.Add(reader.GetString(0));
                }
                con.Close();
                return vrni;
            }
        }
        public List<Champion> GetChampions()
        {
            List<Champion> vrni = new List<Champion>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM champions;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni.Add(new Champion(reader.GetInt32(0), reader.GetString(1)));
                }
                con.Close();
                return vrni;
            }
        }
        public Champion GetChampion(int id)
        {
            Champion vrni = null;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM champions WHERE champion_id = " + id + ";", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = new Champion(reader.GetInt32(0), reader.GetString(1));
                }
                con.Close();
                return vrni;
            }
        }
        public int GetChampionId(string name)
        {
            int vrni = 0;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT champion_id FROM champions WHERE champ_name = '" + name + "';", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = reader.GetInt32(0);
                }
                con.Close();
                return vrni;
            }
        }
        public List<Role> GetRoles()
        {
            List<Role> vrni = new List<Role>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM roles;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni.Add(new Role(reader.GetInt32(0), reader.GetString(1)));
                }
                con.Close();
                return vrni;
            }
        }
        public Role GetRole(int id)
        {
            Role vrni = null;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM roles WHERE role_id = " + id + ";", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = new Role(reader.GetInt32(0), reader.GetString(1));
                }
                con.Close();
                return vrni;
            }
        }
        public int GetRoleId(string name)
        {
            int vrni = 0;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT role_id FROM roles WHERE role_name = '" + name + "';", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = reader.GetInt32(0);
                }
                con.Close();
                return vrni;
            }
        }
        public List<SummonerSpell> GetSummonerSpells()
        {
            List<SummonerSpell> vrni = new List<SummonerSpell>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM summoner_spells;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni.Add(new SummonerSpell(reader.GetInt32(0), reader.GetString(1)));
                }
                con.Close();
                return vrni;
            }
        }
        public SummonerSpell GetSummonerSpell(int id)
        {
            SummonerSpell vrni = null;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM summoner_spells WHERE summoner_spell_id = " + id + ";", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = new SummonerSpell(reader.GetInt32(0), reader.GetString(1));
                }
                con.Close();
                return vrni;
            }
        }
        public int GetSummonerSpellId(string name)
        {
            int vrni = 0;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT summoner_spell_id FROM summoner_spells WHERE summoner_spell_name = '" + name + "';", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = reader.GetInt32(0);
                }
                con.Close();
                return vrni;
            }
        }
        public List<Match> GetMatches()
        {
            List<Match> vrni = new List<Match>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT match_id, champion_id, role_id, summoner_spell1_id, summoner_spell2_id, kills, deaths, assists, date, creep_score, vision_score, match_lenght, drake, rift_herald, baron, win FROM matches;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Champion champ = GetChampion(reader.GetInt32(0));
                    Role role = GetRole(reader.GetInt32(2));
                    SummonerSpell summonerSpell1 = GetSummonerSpell(reader.GetInt32(3));
                    SummonerSpell summonerSpell2 = GetSummonerSpell(reader.GetInt32(4));
                    vrni.Add(new Match(reader.GetInt32(0), champ, role, summonerSpell1, summonerSpell2, reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetBoolean(15)));
                }
                con.Close();
                return vrni;
            }
        }
        public Match GetMatch(int id)
        {
            Match vrni = new Match();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT match_id, champion_id, role_id, summoner_spell1_id, summoner_spell2_id, kills, deaths, assists, date, creep_score, vision_score, match_lenght, drake, rift_herald, baron, win " +
                    "FROM matches WHERE(match_id = " + id + ");", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Champion champ = GetChampion(reader.GetInt32(0));
                    Role role = GetRole(reader.GetInt32(2));
                    SummonerSpell summonerSpell1 = GetSummonerSpell(reader.GetInt32(3));
                    SummonerSpell summonerSpell2 = GetSummonerSpell(reader.GetInt32(4));
                    vrni = new Match(reader.GetInt32(0), champ, role, summonerSpell1, summonerSpell2, reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetDateTime(8), reader.GetInt32(9), reader.GetInt32(10), reader.GetInt32(11), reader.GetInt32(12), reader.GetInt32(13), reader.GetInt32(14), reader.GetBoolean(15));
                }
                con.Close();
                return vrni;
            }
        }
        public void RemoveMatch(int id)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("DELETE FROM matches WHERE match_id = " + id + ";", con);
                com.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<string> GetItems()
        {
            List<string> vrni = new List<string>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT item_name FROM items;", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni.Add(reader.GetString(0));
                }
                con.Close();
                return vrni;
            }
        }
        public int GetItemId(string item_name)
        {
            int vrni = 0;
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT item_id FROM items WHERE item_name = '" + item_name + "';", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    vrni = reader.GetInt32(0);
                }
                con.Close();
                return vrni;
            }
        }
        public List<Champion> GetEnemyTeamByMatch(Match match)
        {
            List<Champion> EnemyTeam = new List<Champion>();
            using (NpgsqlConnection con = new NpgsqlConnection("Server=localhost; User Id=postgres; Password=postgres; Database=diplomska_db;"))
            {
                con.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT top_id, jungle_id, middle_id, adc_id, support_id FROM enemy_team WHERE enemy_team_id = " + match.Id + ";", con);
                NpgsqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    EnemyTeam.Add(GetChampion(reader.GetInt32(0)));
                    EnemyTeam.Add(GetChampion(reader.GetInt32(1)));
                    EnemyTeam.Add(GetChampion(reader.GetInt32(2)));
                    EnemyTeam.Add(GetChampion(reader.GetInt32(3)));
                    EnemyTeam.Add(GetChampion(reader.GetInt32(4)));
                }
                con.Close();
                return EnemyTeam;
            }
        }
    }
}

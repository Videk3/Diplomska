using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska
{
    internal class Match
    {
        public int Id { get; set; }
        public Champion Champion { get; set; }
        public Role Role { get; set; }
        public SummonerSpell SummonerSpell1 { get; set; }
        public SummonerSpell SummonerSpell2 { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public DateTime Date { get; set; }
        public int CreepScore { get; set; }
        public int VisionScore { get; set; }
        public int MatchLength { get; set; }
        public int Drake { get; set; }
        public int RiftHerald { get; set; }
        public int Baron { get; set; }
        public int EnemyTeam { get; set; } //WIP

        public Match(int id, Champion champion, Role role, SummonerSpell summonerSpell1, SummonerSpell summonerSpell2, int kills, int deaths, int assists)
        {
            Id = id;
            Champion = champion;
            Role = role;
            SummonerSpell1 = summonerSpell1;
            SummonerSpell2 = summonerSpell2;
            Kills = kills;
            Deaths = deaths;
            Assists = assists;
        }
    }
}

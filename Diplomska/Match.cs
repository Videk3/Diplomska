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
        public int EnemyTeam { get; set; }
        public bool Win { get; set; }

        public Match(int id, Champion champion, Role role, SummonerSpell summonerSpell1, SummonerSpell summonerSpell2, int kills, int deaths, int assists, DateTime date, int creepScore, int visionScore, int matchLenght, int drake, int riftHerald, int baron, bool win)
        {
            Id = id;
            Champion = champion;
            Role = role;
            SummonerSpell1 = summonerSpell1;
            SummonerSpell2 = summonerSpell2;
            Kills = kills;
            Deaths = deaths;
            Assists = assists;
            Date = date;
            CreepScore = creepScore;
            VisionScore = visionScore;
            MatchLength = matchLenght;
            Drake = drake;
            RiftHerald = riftHerald;
            Baron = baron;
            Win = win;
        }
    }
}

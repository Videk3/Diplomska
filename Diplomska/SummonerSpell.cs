using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska
{
    internal class SummonerSpell
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SummonerSpell(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplomska
{
    internal class Champion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Champion()
        {
        }
        public Champion(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}

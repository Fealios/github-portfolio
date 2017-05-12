using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitPortfolio.Models
{
    public class Repo
    {
        public string Name { get; set; }
        public string GitUrl { get; set; }
        public int StarCount { get; set; }
    }
}

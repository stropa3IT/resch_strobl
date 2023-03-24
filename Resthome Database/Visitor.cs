using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resthome_Database
{
    internal class Visitor : Personal 
    {
        public Visitor(string firstname, string lastname, int id, int age, DateTime day) : base(firstname, lastname, id, age)
        {
            this.Day = day;
        }

        public DateTime Day { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicap.Models
{
    public class Round : Document
    {
        public int ID { get; set; }
        public string Course { get; set; }
        public int Score { get; set; }
        public int Slope { get; set; }
        public float Rating { get; set; }
        public float ScoreDifferential { get; set; }
        //public DateTime TimeStamp { get; set; }


        public Round()
        {

        }
    }
}


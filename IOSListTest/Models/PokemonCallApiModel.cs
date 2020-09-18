using System;
using System.Collections.Generic;

namespace IOSListTest.Models
{
      public class PokemonCallApiModel
        {
            public int count { get; set; }
            public string next { get; set; }
            public string previous { get; set; }
            public IList<Result> results { get; set; }
        }

        public class Result
        {
            public string name { get; set; }
            public string url { get; set; }
        }
    
}

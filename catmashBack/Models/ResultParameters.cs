using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace catmashBack.Models
{
    public class ResultParameters
    {
        public string appId { get; set; }
        public string opponentCatId { get; set; }
        public int outcome { get; set; }
    }
}
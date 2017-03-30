using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class Ranker
    {
        public static double rank(double tags, double distFromLength, double commonTags)
        {
            double result = (tags + distFromLength + commonTags) / 3;
            return result;
        }
    }
}

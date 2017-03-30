using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class Ranker
    {

        public static double rank(double tags, double distFromLegth, double communTags)
        {
            double result = (tags + distFromLegth + communTags) / 3;
            return result;
        }
    }
}

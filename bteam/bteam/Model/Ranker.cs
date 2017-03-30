using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class Ranker
    {
        public static double rank(double distFromTagsFreq, double distFromWordsLength, double commonTagsMiss)
        {
            double result = (distFromTagsFreq + distFromWordsLength + commonTagsMiss) / 3;
            return result;
        }
    }
}

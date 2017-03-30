using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public class Ranker
    {

        public double rank(double tags, double distFromLength, double commonTags, Dictionary<string, int> frequencies)
        {
            double result = (tags + distFromLength + commonTags) / 3;
            return result;
        }
    }
}

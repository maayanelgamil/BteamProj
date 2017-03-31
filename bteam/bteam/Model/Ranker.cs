using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public class Ranker
    {
        public double rank(double tagDifference, double usersWords, double missingTag)
        {
            return 0.33 * tagDifference + 0.34 * usersWords + 0.33 * missingTag;
        }
    }
}

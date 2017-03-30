using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class CalculateTagsDifference
    {
        public static Dictionary<string,double> getUserTagsDifference(Dictionary<string, Dictionary<string, int>> usersTagsFrequency)
        {
            Dictionary<string, int> usersNumOfTags = new Dictionary<string, int>();
            Dictionary<string, double> differenceFromAverage = new Dictionary<string, double>();
            int sum = 0;
            int count = 0;
            int tmp = 0;
            foreach (string user in usersTagsFrequency.Keys)
            {
                foreach (string tag in usersTagsFrequency[user].Keys)
                {
                    tmp = usersTagsFrequency[user][tag];

                    if (!usersNumOfTags.ContainsKey(user))
                        usersNumOfTags.Add(user, tmp);
                    else
                        usersNumOfTags[user] += tmp;

                    sum += tmp;
                    count++;
                }
            }
            double average = sum / count;
            foreach (string user in usersNumOfTags.Keys)
                differenceFromAverage.Add(user, usersNumOfTags[user] - average);
            return differenceFromAverage;
        }
    }
}

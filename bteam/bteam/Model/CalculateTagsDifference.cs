using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class CalculateTagsDifference
    {
        public static Dictionary<string,int> getUserTagsDifference(Dictionary<string, Dictionary<string, int>> usersTagsFrequency)
        {
            Dictionary<string, int> usersNumOfTags = new Dictionary<string, int>();
            Dictionary<string, double> differenceFromAverage = new Dictionary<string, double>();
            int sum = 0;
            int tmp = 0;
            int count = 0;
            foreach (string user in usersTagsFrequency.Keys)
            {
                tmp = getNumOfWords(userFiles[user]);
                usersNumOfWords.Add(user, tmp);
                sum += tmp;
                count++;
            }
            double average = sum / count;
            foreach (string user in userFiles.Keys)
                differenceFromAverage.Add(user, usersNumOfWords[user] - average);
            return differenceFromAverage;
        }
    }
}

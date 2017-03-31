using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class CalculateFrequentTagsMissing
    {

        public static Dictionary<string, double> getTopPercentageFrequentTags(Dictionary<string, Dictionary<string, int>> usersTagsFrequency, double percentage)
        {
            Dictionary<string, int> tagFrequency = new Dictionary<string, int>();
            Dictionary<string, int> usersFrequentTagsCount = new Dictionary<string, int>();
            tagFrequency = getTotalTagFrequency(usersTagsFrequency);


            double top = (tagFrequency.Count * (percentage / 100)); //calculate the amount of tags to get
            List<int> arr = tagFrequency.Values.ToList(); //sort the tags
            arr.Sort();
            int _top = (int)top;



            int limit = arr[tagFrequency.Count - 1 - _top]; //Sets the limit for being frequent tag
            Dictionary<string, int> frequentTags = new Dictionary<string, int>();

            foreach (string tag in tagFrequency.Keys)
            {
                if (tagFrequency[tag] > limit) //gets only the tags 
                    frequentTags.Add(tag, tagFrequency[tag]);
            }

            int min = int.MaxValue;
            int max = 0;

            //count missing frequent per user
            foreach (string user in usersTagsFrequency.Keys)
            {
                if (!usersFrequentTagsCount.ContainsKey(user))
                {
                    usersFrequentTagsCount.Add(user, 0);
                }
                foreach (string frequentTag in frequentTags.Keys)
                {
                    if (!(usersTagsFrequency[user].ContainsKey(frequentTag)))
                        usersFrequentTagsCount[user]++;
                }

                if (usersFrequentTagsCount[user] > max)
                    max = usersFrequentTagsCount[user];

                if (usersFrequentTagsCount[user] < min)
                    min = usersFrequentTagsCount[user];
            }

            //compute the rank for each user
            Dictionary<string, double> usersMissingFrequentTagsRank = new Dictionary<string, double>();
            foreach (string user in usersTagsFrequency.Keys)
            {
                if (max == 0)
                    usersMissingFrequentTagsRank[user] = 0;
                else
                usersMissingFrequentTagsRank[user] = (max - usersFrequentTagsCount[user]) / max;
            }
          

            return usersMissingFrequentTagsRank; //return only top frequency tags
        }

        public static Dictionary<string, int> getTotalTagFrequency(Dictionary<string, Dictionary<string, int>> usersTagsFrequency)
        {
            Dictionary<string, int> tagFrequency = new Dictionary<string, int>();

            foreach (string user_id in usersTagsFrequency.Keys)
            {
                foreach (string tag in usersTagsFrequency[user_id].Keys)
                {
                    if (!(tagFrequency.ContainsKey(tag)))
                        tagFrequency[tag] = 0;

                    tagFrequency[tag] += usersTagsFrequency[user_id][tag];
                }
            }
            return tagFrequency;
        }

        public static Dictionary<string, int> numOfMissingTags(Dictionary<string, Dictionary<string, int>> usersTagsFrequency, Dictionary<string, int> topPercentageTag)
        {
            Dictionary<string, int> tagsPerUser = new Dictionary<string, int>();
            foreach (string user in usersTagsFrequency.Keys)
            {
                if (topPercentageTag.ContainsKey(user))
                    tagsPerUser[user]++;
            }
            return tagsPerUser;
        }
    }
}

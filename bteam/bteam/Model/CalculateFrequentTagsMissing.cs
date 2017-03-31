using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class CalculateFrequentTagsMissing
    {

        public static Dictionary<string, int> getTopPercentageFrequentTags(Dictionary<string, Dictionary<string, int>> usersTagsFrequency, double percentage)
        {
            Dictionary<string, int> tagFrequency = new Dictionary<string, int>();
            tagFrequency = getTotalTagFrequency(usersTagsFrequency);


            double top = (tagFrequency.Count * (percentage / 100)); //calculate the amount of tags to get
            List<int> arr = tagFrequency.Values.ToList(); //sort the tags
            arr.Sort();
            int _top = (int)top;

            int limit = arr[tagFrequency.Count - 1 - _top]; //Sets the limit for being frequent tag
            Dictionary<string, int> tmp = new Dictionary<string, int>();

            foreach (string tag in tagFrequency.Keys)
            {
                if (tagFrequency[tag] > limit) //gets only the tags 
                    tmp.Add(tag, tagFrequency[tag]);
            }

            tagFrequency = tmp;
            return tagFrequency;
        }

        public static Dictionary<string, int> getTotalTagFrequency(Dictionary<string, Dictionary<string, int>> usersTagsFrequency)
        {
            Dictionary<string, int> tagFrequency = new Dictionary<string, int>();

            Dictionary<string, double> frequencyRank = new Dictionary<string, double>();
            int min = int.MaxValue;
            int max = 0;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class CalculateFrequentTagsMissing
    {

       public static Dictionary<string, int> getTopPercentageFrequentTags(Dictionary<string, Dictionary<string, int>> usersTagsFrequency,double percentage)
        {
            Dictionary<string, int> topPercentageTags = new Dictionary<string, int>();
            foreach (string user_id in usersTagsFrequency.Keys)
            {
                foreach (string tag in usersTagsFrequency[user_id].Keys)
                {
                    if (!(topPercentageTags.ContainsKey(tag)))
                        topPercentageTags[tag] = 0;

                    topPercentageTags[tag] += usersTagsFrequency[user_id][tag];
                }
            }
            double top = (topPercentageTags.Count * (percentage/100)); //calculate the amount of tags to get
            List<int> arr = topPercentageTags.Values.ToList(); //sort the tags
            arr.Sort();
            int _top = (int)top;

            int limit = arr[topPercentageTags.Count-1-_top]; //Sets the limit for being frequent tag
            Dictionary<string, int> tmp = new Dictionary<string, int>();

            foreach (string tag in topPercentageTags.Keys)
            {
                if (topPercentageTags[tag] > limit) //gets only the tags 
                    tmp.Add(tag, topPercentageTags[tag]);
            }
            topPercentageTags = tmp;
            return topPercentageTags;
        }



        public static Dictionary<string,int> numOfMissingTags(Dictionary<string, Dictionary<string, int>> usersTagsFrequency,Dictionary<string,int> topPercentageTag)
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

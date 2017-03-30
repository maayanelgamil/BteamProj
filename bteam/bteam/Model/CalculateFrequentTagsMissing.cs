using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public class CalculateFrequentTagsMissing
    {
        Dictionary<string, Dictionary<string, int>> usersTagsFrequency;
        Dictionary<string, int> top10PercentageTags;

        public CalculateFrequentTagsMissing(Dictionary<string ,Dictionary<string ,int>> _usersTagsFrequency)
        {
            usersTagsFrequency = _usersTagsFrequency;
            top10PercentageTags = new Dictionary<string, int>();
        }
       void getTop10PercentageFrequentTags()
        {
            foreach(string user_id in usersTagsFrequency.Keys)
            {
                foreach (string tag in usersTagsFrequency[user_id].Keys)
                {
                    if (!(top10PercentageTags.ContainsKey(tag)))
                        top10PercentageTags[tag] = 0;

                    top10PercentageTags[tag] += usersTagsFrequency[user_id][tag];
                }
            }
            int top = top10PercentageTags.Count / 10; //calculate the amount of tags to get
            List<int> arr = top10PercentageTags.Values.ToList(); //sort the tags
            arr.Sort();

            int limit = arr[top];
            Dictionary<string, int> tmp = new Dictionary<string, int>();

            foreach (string tag in top10PercentageTags.Keys)
            {
                if (top10PercentageTags[tag] > limit)
                    tmp.Add(tag, top10PercentageTags[tag]);
            }
            top10PercentageTags = tmp;
        }

        Dictionary<string,int> numOfMissingTags()
        {
            return null;
        }
    }
}

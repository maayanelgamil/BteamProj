using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class html
    {
        public static Dictionary<string,int> getTagsFromFile(string filePath)
        {
            Dictionary<string, int> res = new Dictionary<string, int>();
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);
            List<HtmlNode> allNodes = new List<HtmlNode>(htmlDoc.DocumentNode.Descendants());
            foreach(HtmlNode node in allNodes)
            {
                if (res.ContainsKey(node.Name))
                    res[node.Name]++;
                else
                    res.Add(node.Name, 1);
            }
            return res;
        }
    }
}

using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
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
            string htmlString;
            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    htmlString = reader.ReadToEnd();
                }
            }
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(htmlString);
            List<HtmlNode> allNodes = new List<HtmlNode>(htmlDoc.DocumentNode.Descendants());
            foreach(HtmlNode node in allNodes)
            {
                if (res.ContainsKey(node.Name))
                    res[node.Name]++;
                else if(!node.Name.Contains('#'))
                    res.Add(node.Name, 1);
            }
            return res;
        }
    }
}

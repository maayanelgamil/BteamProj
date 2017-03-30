using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using bteam.Model;

namespace bteam
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Dictionary<string, int> dict = html.getTagsFromFile("C: \\Users\\Kulik\\Desktop\\Lab2\\Lab2_Exercise\\index.html");
            Dictionary<string, Dictionary<string, int>> dictdict = new Dictionary<string, Dictionary<string, int>>();
            dictdict.Add("user1", dict);

            Dictionary<string, int> top10PercentageTags = new Dictionary<string, int>();
            top10PercentageTags = CalculateFrequentTagsMissing.getTopPercentageFrequentTags(dictdict,50);
            foreach (string tag in top10PercentageTags.Keys) 
                MessageBox.Show(tag+" "+top10PercentageTags[tag].ToString());
        }
    }
}

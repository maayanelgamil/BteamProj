using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{

    public class Parser
    {
        HashSet<char> punctuation;
        public Parser()
        {
            initPunctuation();
        }

        public string[] split(string toSplit)
        {
            return toSplit.Split(punctuation.ToArray(),StringSplitOptions.RemoveEmptyEntries);
        }

        private void initPunctuation()
        {
            punctuation = new HashSet<char>();
            char[] signs = {'^', '?', '!', '/', '*', '_', '+', '=', '\\', '\n', '~','`' ,' ','\t'};
            punctuation.UnionWith(signs);
        }
    }
}

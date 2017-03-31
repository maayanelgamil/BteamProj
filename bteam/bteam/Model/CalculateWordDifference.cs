using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    public static class CalculateWordDifference
    {
        public static Dictionary<string, double> getUserWordDifference(Dictionary<string,string> userFiles)
        {
            Dictionary<string, int> usersNumOfWords = new Dictionary<string, int>();
            Dictionary<string, double> differenceFromAverage = new Dictionary<string, double>();
            int sum = 0;
            int tmp = 0;
            int count = 0;
            int min = int.MaxValue;
            int max = 0;

            foreach (string user in userFiles.Keys)
            {
                tmp = getNumOfWords(userFiles[user]);

                if (tmp < min)
                    min = tmp;

                if (tmp > max)
                    max = tmp;

                usersNumOfWords.Add(user, tmp);
                sum += tmp;
                count++;
            }
            double average = sum / count;
            foreach (string user in userFiles.Keys)
            {
                double value = (double)(usersNumOfWords[user] - min) / (double)(max - min);
                if (value == 0)
                    value = (double)min / max;
                if (value == 1)
                    value = (double)(max - min) / max;
                differenceFromAverage.Add(user, value);
            }
            return differenceFromAverage;
        }

        public static int getNumOfWords(string file)
        {
            string textFile;
            Parser parser = new Parser();
            using (FileStream stream = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    textFile = reader.ReadToEnd();
                }
            }
            return parser.split(textFile).Count();
        }
    }

}

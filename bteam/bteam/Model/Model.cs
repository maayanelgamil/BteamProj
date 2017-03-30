using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam.Model
{
    class Model
    {
        int _numOfWords = 0;
        Dictionary<string, double> _users = new Dictionary<string, double>();
        public Model()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (string file in files)
            {
                _users.Add(file, 0);
            }
        }



        public int getNumOfWords(string path)
        {
            int result;
            string text;
            using (StreamReader streamReader = new StreamReader(path))
            {
                text = streamReader.ReadToEnd();
            }
            result = text.Split(' ').Length;
            return result;
        }


        public Dictionary<string, double> rank(string filePath)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            foreach (string file in _users.Keys)
            {
                int numOfWords = getNumOfWords(file);
                _numOfWords += numOfWords;

            }
            double avgNumOfWords = _numOfWords / _users.Keys.Count;


            return result;
        }


        public Dictionary<string, double> calculate(Dictionary<string, Dictionary<string, double>> userDic)
        {
            Dictionary<string, double> result = new Dictionary<string, double>();

            foreach (KeyValuePair<string, Dictionary<string, double>> kp in userDic)
            {

            }

            return result;
        }
    }
}

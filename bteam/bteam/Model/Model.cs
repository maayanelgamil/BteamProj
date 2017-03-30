using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace bteam.Model
{
    public class Model : INotifyPropertyChanged
    {
        // Contains the users and their progress
        Dictionary<string, double> _users = new Dictionary<string, double>();

        // Indicates the model to stop working
        bool _stop = false;

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// C'thor
        /// </summary>
        public Model()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach (string file in files)
            {
                _users.Add(file, 0);
            }


        }

        /// <summary>
        /// Start's the model
        /// </summary>
        public void start()
        {
            new Thread(() =>
            {
                while (!_stop)
                {
                    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());

                    foreach (string file in files)
                    {
                        _users[file] = calculatePrograss(file);

                    }
                }
            });
        }

        /// <summary>
        /// calculate the prograss of the given 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private double calculatePrograss(string file)
        {
            throw new NotImplementedException();
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

        public Dictionary<string, int> userDistanceFromAverage()
        {
            return null;
        }


        public double calcAvgFileLength(string filePath)
        {
            int numOfWords = 0;
            foreach (string file in _users.Keys)
            {
                int num = getNumOfWords(file);
                numOfWords += num;

            }
            double avgNumOfWords = numOfWords / _users.Keys.Count;
            return avgNumOfWords;
        }

        public void getFrequent()
        {
            Dictionary<string, Dictionary<string, int>> usersTagsFrequency = new Dictionary<string, Dictionary<string, int>>();
            foreach (string fileName in _users.Keys)
            {
                Dictionary<string, int> frequent = html.getTagsFromFile(fileName);
                usersTagsFrequency.Add(fileName, frequent);
            }

            Dictionary<string, int> result = CalculateFrequentTagsMissing.getTopPercentageFrequentTags(usersTagsFrequency, 10);
        }
    }
}

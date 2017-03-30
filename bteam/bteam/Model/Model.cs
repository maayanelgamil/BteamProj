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

        //Property for the users ranking
        public Dictionary<string, double> Users
        {
            get
            {
                return _users;
            }
        }


        // Indicates the model to stop working
        bool _stop = false;

        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// C'thor
        /// </summary>
        public Model()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\Users");

            foreach (string file in files)
            {
                _users.Add(file, 0);
                notifyPropertyChanged("Users");//notify that the progress has changed
            }


        }

        /// <summary>
        /// Wrapper function for property changed
        /// </summary>
        /// <param name="propertyName"></param>
        void notifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
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


                    foreach (string file in _users.Keys.ToList())
                    {

                        _users[file] = calculateProgress(file);
                        notifyPropertyChanged("Users");//notify that the progress has changed

                    }
                    Thread.Sleep(5000);
                }
            }).Start();
        }

        /// <summary>
        /// calculate the prograss of the given user file
        /// </summary>
        /// <param name="file">the given user file</param>
        /// <returns>the prograss</returns>
        private double calculateProgress(string file)
        {
            return _users[file] + 1;
        }


        public void calculateProgress()
        {
            Dictionary<string, Dictionary<string, int>> usersTagsFrequency = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, string> usersFiles = new Dictionary<string, string>();

            foreach (string fileName in _users.Keys)
            {
                Dictionary<string, int> frequent = html.getTagsFromFile(fileName);
                usersFiles.Add(fileName, fileName);
                usersTagsFrequency.Add(fileName, frequent);
            }

            Dictionary<string, int> numOfMissingTag = CalculateFrequentTagsMissing.getTopPercentageFrequentTags(usersTagsFrequency, 10);
            Dictionary<string, double> usersTagDifference = CalculateTagsDifference.getUserTagsDifference(usersTagsFrequency);
            Dictionary<string, double> usersWordsDifference = CalculateWordDifference.getUserWordDifference(usersFiles);
            Ranker ranker = new Ranker();

            foreach (string user in usersFiles.Keys)
                Users[user] = ranker.rank(usersTagDifference[user], usersWordsDifference[user], numOfMissingTag[user]);

        }
    }
}

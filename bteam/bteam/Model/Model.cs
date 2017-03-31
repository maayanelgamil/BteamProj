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

        double _user1 = 0;
        public double User1
        {
            get
            {
                return _user1;
            }
        }

        double _user2 = 0;
        public double User2
        {
            get
            {
                return _user2;
            }
        }

        double _user3 = 0;
        public double User3
        {
            get
            {
                return _user3;
            }
        }

        double _user4 = 0;
        public double User4
        {
            get
            {
                return _user4;
            }
        }

        double _user5 = 0;
        public double User5
        {
            get
            {
                return _user5;
            }
        }

        double _user6 = 0;
        public double User6
        {
            get
            {
                return _user6;
            }
        }

        double _user7 = 0;
        public double User7
        {
            get
            {
                return _user7;
            }
        }

        double _user8 = 0;
        public double User8
        {
            get
            {
                return _user8;
            }
        }


        double avg = 0;
        public double Avg
        {
            get
            {
                return avg;
            }
            set { avg = value; notifyPropertyChanged("Avg"); }
        }

        Thread model_thread;

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
            model_thread = new Thread(() =>
              {
                  while (!_stop)
                  {
                      calculateProgress();
                      Thread.Sleep(500);
                  }
              });
            model_thread.Start();
        }

        public void stop()
        {
            _stop = true;
            while (model_thread.IsAlive) ;
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

            Dictionary<string, double> numOfMissingTag = CalculateFrequentTagsMissing.getTopPercentageFrequentTags(usersTagsFrequency, 35);
            Dictionary<string, double> usersTagDifference = CalculateTagsDifference.getUserTagsDifference(usersTagsFrequency);
            Dictionary<string, double> usersWordsDifference = CalculateWordDifference.getUserWordDifference(usersFiles);
            Ranker ranker = new Ranker();

            int counter = 1;
            foreach (string user in usersFiles.Keys)
            {
                _users[user] = ranker.rank(usersTagDifference[user], usersWordsDifference[user], numOfMissingTag[user]);
                if (counter == 1)
                {
                    _user1 = _users[user];
                    notifyPropertyChanged("User1");//notify that the progress has changed
                }
                else if (counter == 2)
                {
                    _user2 = _users[user];
                    notifyPropertyChanged("User2");//notify that the progress has changed
                }
                else if (counter == 3)
                {
                    _user3 = _users[user];
                    notifyPropertyChanged("User3");//notify that the progress has changed
                }
                else if (counter==4)
                {
                    _user4 = _users[user];
                    notifyPropertyChanged("User4");//notify that the progress has changed
                }
                else if (counter == 5)
                {
                    _user5 = _users[user];
                    notifyPropertyChanged("User5");//notify that the progress has changed
                }
                else if (counter == 6)
                {
                    _user6 = _users[user];
                    notifyPropertyChanged("User6");//notify that the progress has changed
                }
                else if (counter == 7)
                {
                    _user7 = _users[user];
                    notifyPropertyChanged("User7");//notify that the progress has changed
                }
                else if (counter == 8)
                {
                    _user8 = _users[user];
                    notifyPropertyChanged("User8");//notify that the progress has changed
                }
                counter++;
            }
            double sum = 0;
            foreach (string user in _users.Keys.ToList())
            {
                sum += _users[user];
            }
            Avg = (double)(sum / (double)_users.Keys.Count);
        }
    }
}

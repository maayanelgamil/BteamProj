﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bteam
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bteam.Model.Model m_model;

        public ViewModel(bteam.Model.Model model)
        {
            m_model = model;

            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
            };
        }

        public Dictionary<string, double> Users
        {
            get
            {
                return m_model.Users;
            }
        }

        //public double User1
        //{
        //    return m_model.User1;
        //}

        //public double User2
        //{
        //    return m_model.User2;
        //}

        //public double User3
        //{
        //    return m_model.User3;
        //}

        //public double User4
        //{
        //    return m_model.User4;
        //}

        public void start()
        {
            m_model.start();
        }

    }
}

﻿using System;
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
        private void OnStartup(StartupEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}

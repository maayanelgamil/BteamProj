﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bteam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel m_vm;

        public MainWindow()
        {
            InitializeComponent();
            m_vm = new ViewModel(new bteam.Model.Model());
            DataContext = m_vm;
            m_vm.start();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();

        }
    }
}

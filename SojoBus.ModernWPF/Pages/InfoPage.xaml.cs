﻿using SojoBus.Core.ViewModel;
using System;
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

namespace SojoBus.ModernWPF {
    /// <summary>
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : UserControl {

        private BusViewModel busViewModel = new BusViewModel();

        public InfoPage() {
            InitializeComponent();
            info.DataContext = busViewModel;
            load();
        }

        private void load() {
            busViewModel.LoadInfo.Execute();
        }

        private void Button_Click(object sender,RoutedEventArgs e) {
            load();
        }
    }
}

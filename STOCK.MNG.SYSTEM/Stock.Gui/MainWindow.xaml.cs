﻿using System.Windows;

namespace Stock.Gui {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new vpoutput.MainViewModel();
        }
    }
}

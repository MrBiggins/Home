using System;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls;
using Stock.Gui.Events;
using Stock.Gui.ViewModel;

namespace Stock.Gui.Views {
    /// <summary>
    /// Interaction logic for ManageBranches.xaml
    /// </summary>
    public partial class ManageBranches : MetroWindow {
        public ManageBranches() {
            InitializeComponent();
            DataContext = new ManageBranchViewModel();
            Messenger.Default.Register<RiseClosingEvent>(this, CloseEventHandler);
        }

        private void CloseEventHandler(RiseClosingEvent obj) {

            Close();
        }

        private void ManageBranches_OnClosing(object sender, CancelEventArgs e) {
            Messenger.Default.Unregister(this);
        }
    }
}

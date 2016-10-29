using System.Windows.Controls;

namespace Stock.Gui.Views {
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration
    {
        public Configuration() {
            InitializeComponent();
            DataContext = new vpoutput.ConfigurationViewModel();
        }
    }
}

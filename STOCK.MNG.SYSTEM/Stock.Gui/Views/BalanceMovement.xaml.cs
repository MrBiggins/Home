namespace Stock.Gui.Views {
    /// <summary>
    /// Interaction logic for BalanceMovement.xaml
    /// </summary>
    public partial class BalanceMovement
    {
        public BalanceMovement() {
            InitializeComponent();
            DataContext = new vpoutput.BalanceMovementViewModel();
        }
    }
}

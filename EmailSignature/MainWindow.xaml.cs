using EmailSignature.Views;
using System.Windows;

namespace EmailSignature
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region - - - - - - Constructors - - - - - -

        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion Constructors

        #region - - - - - - Events - - - - - -

        private void MainWindowEditEmail_Button_Click(object sender, RoutedEventArgs e)
        {
            var _EditEmailView = new EditEmailView();
            _EditEmailView.Show();
        }

        #endregion Events
    }

}

using EmailSignature.Views;
using System.Windows;

namespace EmailSignature
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _EditSignatureView = new EditSignatureView();
            _EditSignatureView.Show();
        }
    }
}
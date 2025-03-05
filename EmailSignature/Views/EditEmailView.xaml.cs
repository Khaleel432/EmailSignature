using EmailSignature.ViewModels;
using System.Diagnostics;
using System.Windows;

namespace EmailSignature.Views
{

    /// <summary>
    /// Interaction logic for EditEmailView.xaml
    /// </summary>
    public partial class EditEmailView : Window
    {

        #region - - - - - - Fields - - - - - -

        private readonly EditEmailViewModel m_ViewModel;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EditEmailView()
        {
            this.InitializeComponent();
            this.m_ViewModel = new EditEmailViewModel();
            this.DataContext = this.m_ViewModel.m_Email;
        }

        #endregion Constructors

        #region - - - - - - Events - - - - - -

        #endregion Events

        private void EditEmailViewSendEmail_Button_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Sending email");
        }

        private void EditEmailViewLoadSignature_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditEmailViewUpdateSignature_Button_Click(object sender, RoutedEventArgs e)
        {
            var _EditSignatureView = new EditSignatureView();
            _EditSignatureView.DataContext = this.m_ViewModel.m_Email;
            _EditSignatureView.m_ViewModel.m_Email = this.m_ViewModel.m_Email;
            _EditSignatureView.Show();
        }
    }

}

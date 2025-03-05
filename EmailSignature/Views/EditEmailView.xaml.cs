using EmailSignature.ViewModels;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

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

        #region - - - - - - Methods - - - - - -

        void SetRtf(RichTextBox rt, string rtfString)
        {
            var _Stream = new MemoryStream(Encoding.UTF8.GetBytes(rtfString));
            Trace.WriteLine(rtfString);
            rt.Selection.Load(_Stream, DataFormats.Rtf);
        }

        #endregion Methods

        #region - - - - - - Events - - - - - -

        private void EditEmailViewSendEmail_Button_Click(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Sending email");
        }

        private void EditEmailViewLoadSignature_Button_Click(object sender, RoutedEventArgs e)
        {
            var _RtfString = this.m_ViewModel.GetSignature();
            if (!string.IsNullOrEmpty(_RtfString))
                this.SetRtf(this.EditEmailViewEmail_RichTextBox, _RtfString);
        }

        private void EditEmailViewUpdateSignature_Button_Click(object sender, RoutedEventArgs e)
        {
            var _EditSignatureView = new EditSignatureView();
            _EditSignatureView.DataContext = this.m_ViewModel.m_Email;
            _EditSignatureView.m_ViewModel.m_Email = this.m_ViewModel.m_Email;
            _EditSignatureView.Show();
        }

        #endregion Events

    }

}

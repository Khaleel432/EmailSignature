using EmailSignature.Models;
using EmailSignature.ViewModels;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace EmailSignature.Views
{

    /// <summary>
    /// Interaction logic for EditSignatureView.xaml
    /// </summary>
    public partial class EditSignatureView : Window
    {

        #region - - - - - - Fields - - - - - -

        readonly EditSignatureViewModel m_ViewModel;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EditSignatureView()
        {
            this.InitializeComponent();
            var _NewSignature = new EditSignatureModel()
            {
                Signature = "Test signature string",
                UserID = Guid.NewGuid()
            };
            this.m_ViewModel = new EditSignatureViewModel(_NewSignature);
            this.UserID = _NewSignature.UserID;
            //this.EditSignatureUserID_Label.SetBinding(ContentProperty, new Binding("UserID") { Source = this.UserID });
            this.EditSignatureUserID_Label.Content = "UserID: " + this.UserID;
        }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        Guid UserID { get; set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        string GetRtf(RichTextBox rt)
        {
            TextRange _Range = new(rt.Document.ContentStart, rt.Document.ContentEnd);
            MemoryStream _Stream = new();
            _Range.Save(_Stream, DataFormats.Rtf);
            string _RtfText = Encoding.UTF8.GetString(_Stream.ToArray());
            return _RtfText;
        }

        void SetRtf(RichTextBox rt, string rtfString)
        {
            rt.Document.Blocks.Clear();
            var _Stream = new MemoryStream(Encoding.UTF8.GetBytes(rtfString));
            rt.Selection.Load(_Stream, DataFormats.Rtf);
        }

        #endregion Methods

        #region - - - - - - Events - - - - - -

        private void EditSignatureSaveChanges_Button_Click(object sender, RoutedEventArgs e)
        {
            var _RichTextBoxSignature = this.EditSignatureViewSignature_TextBox;
            var _RtfText = this.GetRtf(_RichTextBoxSignature);
            Trace.WriteLine(_RtfText);
            this.m_ViewModel.UpdateSignatureString(_RtfText);
            this.m_ViewModel.UpdateSignature();
        }

        private void EditSignatureViewExit_Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void EditSignatureViewLoadSignature_Button_Click(object sender, RoutedEventArgs e)
        {
            var _RtfString = this.m_ViewModel.GetSignature();
            if (!_RtfString.IsNullOrEmpty())
                this.SetRtf(this.EditSignatureViewSignature_TextBox, _RtfString);

        }

        #endregion Events

    }

}

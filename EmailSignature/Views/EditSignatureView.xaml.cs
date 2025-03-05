using EmailSignature.ViewModels;
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

        public readonly EditSignatureViewModel m_ViewModel;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EditSignatureView()
        {
            this.InitializeComponent();
            this.m_ViewModel = new();
        }

        #endregion Constructors

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
            Trace.WriteLine(rtfString);
            rt.Selection.Load(_Stream, DataFormats.Rtf);
        }

        #endregion Methods

        #region - - - - - - Events - - - - - -

        private void EditSignatureSaveChanges_Button_Click(object sender, RoutedEventArgs e)
        {
            var _RichTextBoxSignature = this.EditSignatureViewSignature_TextBox;
            var _RtfText = this.GetRtf(_RichTextBoxSignature);
            //Trace.WriteLine(_RtfText);
            this.m_ViewModel.SaveSignature(_RtfText);
        }

        private void EditSignatureViewExit_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditSignatureViewLoadSignature_Button_Click(object sender, RoutedEventArgs e)
        {
            var _RtfString = this.m_ViewModel.GetSignature();
            if (!string.IsNullOrEmpty(_RtfString))
                this.SetRtf(this.EditSignatureViewSignature_TextBox, _RtfString);

        }

        #endregion Events

    }

}

using EmailSignature.Models;
using EmailSignature.ViewModels;
using System.Windows;

namespace EmailSignature.Views
{
    /// <summary>
    /// Interaction logic for EditSignatureView.xaml
    /// </summary>
    public partial class EditSignatureView : Window
    {

        #region - - - - - - Fields - - - - - -

        private readonly EditSignatureViewModel m_ViewModel = new();

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public EditSignatureView()
            => this.InitializeComponent();

        #endregion Constructors

        #region - - - - - - Methods - - - - - -
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var _NewSignature = new EditSignatureModel()
            {
                Signature = "Test",
                UserID = Guid.NewGuid()
            };

            this.m_ViewModel.AddSignature(_NewSignature);
        }

        #endregion Methods

    }

}

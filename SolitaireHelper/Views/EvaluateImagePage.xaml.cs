using SolitaireHelper.ViewModels;
using Xamarin.Forms;

namespace SolitaireHelper.Views
{
    public partial class EvaluateImagePage : ContentPage
    {
        readonly EvaluateImageViewModel viewModel;

        public EvaluateImagePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new EvaluateImageViewModel();
        }
    }
}


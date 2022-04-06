using SolitaireHelper.ViewModels;
using Xamarin.Forms;

namespace SolitaireHelper.Views
{
    public partial class HistoryPage : ContentPage
    {
        readonly HistoryViewModel _viewModel;

        public HistoryPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HistoryViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
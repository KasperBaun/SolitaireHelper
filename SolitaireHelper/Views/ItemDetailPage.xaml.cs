using SolitaireHelper.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SolitaireHelper.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
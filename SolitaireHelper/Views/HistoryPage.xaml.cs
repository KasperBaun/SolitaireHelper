using SolitaireHelper.Models;
using SolitaireHelper.ViewModels;
using SolitaireHelper.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SolitaireHelper.Views
{
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel _viewModel;

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
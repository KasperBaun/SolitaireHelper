using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using System;

namespace SolitaireHelper.Views
{
    [QueryProperty(nameof(Path), "path")]
    public partial class EvaluateImagePage : ContentPage
    {
        readonly EvaluateImageViewModel viewModel;

        public string Path
        {
            set { updateViewModel(value); }
        }

        public EvaluateImagePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new EvaluateImageViewModel();
        }
        void updateViewModel(string path)
        {
            try
            {
                viewModel.Photo = path;
                Console.WriteLine("ViewModel.Photo: " + viewModel.Photo);
                viewModel.SendImage();
            }
            catch (Exception)
            {
                Console.Write("Failed to pass path to viewmodel");
            }
        }
    }
}


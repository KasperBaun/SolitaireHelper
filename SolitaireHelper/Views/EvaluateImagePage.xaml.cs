using SolitaireHelper.ViewModels;
using Xamarin.Forms;
using System;

namespace SolitaireHelper.Views
{
    [QueryProperty(nameof(path), "savedPhotoPath")]
    public partial class EvaluateImagePage : ContentPage
    {
        readonly EvaluateImageViewModel viewModel;

        public string path
        {
            get { return path; }
            set { path = value; }
        }

        public EvaluateImagePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new EvaluateImageViewModel();
            Console.WriteLine(path);
        }
    }
}


using SolitaireHelper.ViewModels;
using Xamarin.Forms;

namespace SolitaireHelper.Views
{
    public partial class CameraPage : ContentPage
    {
        readonly CameraViewModel viewModel;

        public CameraPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new CameraViewModel();

        }

        private void cameraView_OnAvailable(object sender, bool e)
        {
            viewModel.OnAvailableChanged(e);
        }

        private async void cameraView_MediaCaptured(object sender, Xamarin.CommunityToolkit.UI.Views.MediaCapturedEventArgs e)
        {
            await viewModel.OnPhotoCapturedAsync(e.ImageData, e.Image);
        }

        private void cameraView_MediaCaptureFailed(object sender, string e)
        {
            viewModel.OnPhotoCaptureFailed(e);
        }
    }
}


using SolitaireHelper.Views;
using Xamarin.Forms;

namespace SolitaireHelper
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GameDetailPage), typeof(GameDetailPage));
            Routing.RegisterRoute(nameof(HistoryPage), typeof(HistoryPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(NewGamePage), typeof(NewGamePage));
            Routing.RegisterRoute(nameof(CameraPage), typeof(CameraPage));
            Routing.RegisterRoute(nameof(EvaluateImagePage), typeof(EvaluateImagePage));
            Routing.RegisterRoute(nameof(LearnHowToPlayPage), typeof(LearnHowToPlayPage));
        }

    }
}

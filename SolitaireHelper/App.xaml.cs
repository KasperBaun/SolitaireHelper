using SolitaireHelper.Services;
using Xamarin.Forms;

namespace SolitaireHelper
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<GameDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

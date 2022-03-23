using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SolitaireHelper.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            PlayNewGame = new Command(async () => await Shell.Current.GoToAsync("NewGamePage"));
            LearnHowToPlay = new Command(async () => await Shell.Current.GoToAsync("LearnHowToPlayPage"));
            SeeHistory = new Command(async () => await Shell.Current.GoToAsync("HistoryPage"));
        }

        public ICommand OpenWebCommand { get; }

        public ICommand PlayNewGame { get; }

        public ICommand LearnHowToPlay { get; }

        public ICommand SeeHistory { get; }
    }
}
using System;
using Xamarin.Forms;
using System.Net.Http;
using System.IO;
using System.ComponentModel;
using System.Text;
using SolitaireHelperModels;

namespace SolitaireHelper.ViewModels
{

    public class EvaluateImageViewModel : BaseViewModel
    {
        private static readonly HttpClient client = new HttpClient();
        string path = "Ikke loaded endnu";
        public Command SendImageCommand { get; }
        public Command BackToNewPictureCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;
        public string Photo
        {
            get => path;
            set
            {
                path = value;
                var args = new PropertyChangedEventArgs(nameof(Photo));
                PropertyChanged?.Invoke(this, args);
            }
        }
        public string BestMove { get; set; } = "Hejsa";
        public EvaluateImageViewModel()
        {
            Title = "Evaluate Image";
            SendImageCommand = new Command(SendImage);
            this.PropertyChanged += (_, __) => SendImageCommand.ChangeCanExecute();
            BackToNewPictureCommand = new Command(BackToNewPicture);
        }


        public string ToBase64(string path)
        {
            var fileStream = File.OpenRead(path);
            MemoryStream memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            Byte[] bytes = memoryStream.ToArray();
            return Convert.ToBase64String(bytes);
        }

        public async void SendImage()
        {
            
            string base64ImageString = ToBase64(path);
            // HTTP-Req til Annika her:
            //Console.WriteLine("### Base64 string: " + base64ImageString);
            //var content = new StringContent(base64ImageString, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            // Modtag object - deserialiser fra JSON til Table objekt
            //var responseString = await response.Content.ReadAsStringAsync();

            // Lav table ud fra response-string
            //Game game = new Game();
            //Table table = new Table();
            //game.PlayGame(table);
        }
        public async void BackToNewPicture()
        {
            await Shell.Current.GoToAsync("CameraPage");
        }
    }
}
using System;
using System.Diagnostics;
using Xamarin.Forms;
using SolitaireHelper.Services;
using System.IO;
using System.ComponentModel;

namespace SolitaireHelper.ViewModels
{

    public class EvaluateImageViewModel : BaseViewModel
    {
        string path = "Ikke loaded endnu";
        public Command SendImageCommand { get; }
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
        public EvaluateImageViewModel()
        {
            Title = "Evaluate Image";
            SendImageCommand = new Command(SendImage);
            this.PropertyChanged += (_, __) => SendImageCommand.ChangeCanExecute();
        }


        public string ToBase64(string path)
        {
            var fileStream = File.OpenRead(path);
            MemoryStream memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            Byte[] bytes = memoryStream.ToArray();
            return Convert.ToBase64String(bytes);
        }

        public void SendImage()
        {
            
            string base64ImageString = ToBase64(path);
            // HTTP-Req til Annika her:
            Console.WriteLine("### Base64 string: " + base64ImageString);
        }
    }
}
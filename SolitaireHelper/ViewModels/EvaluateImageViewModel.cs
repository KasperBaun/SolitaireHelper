using System;
using System.Diagnostics;
using Xamarin.Forms;
using SolitaireHelper.Services;
using System.IO;

namespace SolitaireHelper.ViewModels
{

    public class EvaluateImageViewModel : BaseViewModel
    {
     


        public string ToBase64(string path)
        {
            var fileStream = File.OpenRead(path);
            MemoryStream memoryStream = new MemoryStream();
            fileStream.CopyTo(memoryStream);
            Byte[] bytes = memoryStream.ToArray();
            return Convert.ToBase64String(bytes);
        }
    }
}
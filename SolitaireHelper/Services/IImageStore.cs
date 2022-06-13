using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SolitaireHelper.Services
{
    public interface IImageStore<Image>
    {
        Task<bool> AddImageAsync(string path);
        Task<bool> UpdateImageAsync(Image image);
        Task<bool> DeleteImageAsync(ImageSource source);
        Task<Image> GetImageAsync(string source);
        Task<IEnumerable<Image>> GetImagesAsync(bool forceRefresh = false);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SolitaireHelper.Services
{
    public class ImageStore : IImageStore<Image>
    {
        readonly List<Image> images;

        public ImageStore()
        {
            images = new List<Image>();
          
        }

        public async Task<bool> AddImageAsync(string path)
        {
            Image image = new Image();
            image.Source = path;
            images.Add(image);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateImageAsync(Image image)
        {
            var oldItem = images.Where((Image arg) => arg.Id == image.Id).FirstOrDefault();
            images.Remove(oldItem);
            images.Add(image);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteImageAsync(ImageSource source)
        {
            var oldItem = images.Where((Image arg) => arg.Source == source ).FirstOrDefault();
            images.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Image> GetImageAsync(string source)
        {
            return await Task.FromResult(images.FirstOrDefault(g => g.Source.ToString() == source));
        }

        public async Task<IEnumerable<Image>> GetImagesAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(images);
        }
    }
}
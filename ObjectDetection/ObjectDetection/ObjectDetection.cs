using System.Drawing;
using System.Drawing.Drawing2D;
using YoloParser;
using DataStructures;
using Microsoft.ML;

namespace SolitaireHelper.ObjectDetection
{
    public class ObjectDetection
    {
        public string GetAbsolutePath(string relativePath)
        {
            FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}

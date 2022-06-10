using SolitaireHelperModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SolitaireHelper.Services
{
    public class ReadWriteXML
    {
        public void WriteXML(Object gameData)
        {
            try {
                
                XmlSerializer x = new XmlSerializer(gameData.GetType());
                x.Serialize(Singleton.Instance.filePath, gameData);
            }
            catch(NullReferenceException e) { Console.WriteLine(e.StackTrace); }
        }
    }
    public sealed class Singleton
    {
        private static Singleton instance = null;
        public static string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.xml");
        private FileStream path = File.Create(file);

        public FileStream filePath
        {
            get { return path; }
            set { path = value; }
        }



        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (file)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }
    }
}

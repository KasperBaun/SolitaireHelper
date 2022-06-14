using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace SolitaireHelper.Services
{
    public class ReadWriteXML
    {
        public void WriteXML(Object gameData)
        {
            try
            {
                XmlSerializer x = new XmlSerializer(gameData.GetType());
                x.Serialize(Singleton.Instance.path, gameData);
                x.Serialize(Console.Out, gameData);
                Console.WriteLine(Singleton.Instance.file);
            }
            catch
            {
                Console.WriteLine("ERROR: Serialization Failed!");
            }
            
        }
    }


    public sealed class Singleton
    {
        private static Singleton instance = null;
        private static string _file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.xml");
        private FileStream _path = File.Create(_file);

        public FileStream path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string file
        {
            get { return _file; }
            set { _file = value; }
        }

        Singleton()
        {
        }

        public static Singleton Instance
        {
            get
            {
                lock (_file)
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

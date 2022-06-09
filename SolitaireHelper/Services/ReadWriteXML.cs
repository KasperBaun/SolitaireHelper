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

        public string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.xml");
        public void WriteXML(Object gameData)
        {
            try {
                FileStream path = File.Create(file);
                XmlSerializer x = new XmlSerializer(gameData.GetType());
                x.Serialize(path, gameData);
            }
            catch(NullReferenceException e) { Console.WriteLine(e.StackTrace); }
        }
    }
}

using SolitaireHelperModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolitaireHelper.Services
{
    public class ReadWriteXML
    {
        public void WriteXML(Object gameData)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Game));
            System.IO.FileStream file = System.IO.File.Create("PlayerHistoryData.xml");
            serializer.Serialize(file, gameData);
            file.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CS_DP_Exam_TaskPlanner
{
    class XMLParser
    {
        string Path;
        public XMLParser()
        {
            Path = "C:\\DP_Exam_TakPlanner";  // Папка для хранения файла
        }

        public List<ToDoEntry> LoadList()
        {
            if (!Directory.Exists(Path)) { Directory.CreateDirectory(Path); }

            List<ToDoEntry> loadedList = new List<ToDoEntry>();
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<ToDoEntry>));
            try
            {
                using (Stream fStream = File.OpenRead($"{Path}\\ToDoList.xml"))
                {
                    loadedList = (List<ToDoEntry>)xmlFormat.Deserialize(fStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return loadedList;
        }

        public void SaveList(List<ToDoEntry> listToSave)
        {
            if (!Directory.Exists(Path)) { Directory.CreateDirectory(Path); }

            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<ToDoEntry>));
            try
            {
                using (Stream fStream = File.Create($"{Path}\\ToDoList.xml"))
                {
                    xmlFormat.Serialize(fStream, listToSave);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

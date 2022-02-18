using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolCommunity.Services
{
    public class DataBaseServiceJSON
    {

        public string PathAgendamento { get; set; }

        public DataBaseServiceJSON()
        {
            //PathAgendamento = Environment.CurrentDirectory + @"\DataBaseSchoolCommunity\";
        }

        // C#
        public void SerializarNewtonsoft<T>(List<T> dados, string nmSaida, string path)
        {
            //FileInfo info = new FileInfo(path + nmArquivo);

            DirectoryInfo info1 = new DirectoryInfo(path);

            if (!info1.Exists)
                info1.CreateSubdirectory(path);

            using (var streamWriter = File.CreateText(path + nmSaida))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados, Newtonsoft.Json.Formatting.Indented);
                streamWriter.Write(json);
            }
        }

        public void SerializarUniqueNewtonsoft<T>(T dados, string nmSaida, string path)
        {
            //FileInfo info = new FileInfo(path + nmArquivo);

            DirectoryInfo info1 = new DirectoryInfo(path);

            if (!info1.Exists)
                info1.CreateSubdirectory(path);

            using (var streamWriter = File.CreateText(path + nmSaida))
            {
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(dados, Newtonsoft.Json.Formatting.Indented);
                streamWriter.Write(json);
            }
        }

        public T DeserializarUniqueNewtonsoft<T>(string nmArquivo, string path)
        {
            FileInfo info = new FileInfo(path + nmArquivo);

            if (info.Exists)
            {
                var json = System.IO.File.ReadAllText(path + nmArquivo);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

        public List<T> DeserializarNewtonsoft<T>(string nmArquivo, string path)
        {
            FileInfo info = new FileInfo(path + nmArquivo);

            if (info.Exists)
            {
                try
                {
                    using (var fileStream = new FileStream(path + nmArquivo, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (var textReader = new StreamReader(fileStream))
                    {
                        var content = textReader.ReadToEnd();
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(content);
                    }

                    //using (var json = File.rea.ReadAllText(path + nmArquivo))
                    //{
                    //    json = System.IO.File.ReadAllText(path + nmArquivo);
                    //    return Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                    //}
                }
                catch { return new List<T>(); }
            }
            else
            {
                return new List<T>();
            }
        }

    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace task.Models
{
    class YrLico : Kontragents<YrLico>
    {
        public string NameOfOrganization { get; set; }
        public List<Fiz> fizs { get; set; }

        public YrLico(string org, string iin, string author, DateTime creationdate, List<Fiz> fizs) : base(iin, author, creationdate)
        {
            NameOfOrganization = org;
            this.fizs = fizs;
        }

        public YrLico() : base(string.Empty, string.Empty, DateTime.Now)
        {

        }

        public override void Write(List<YrLico> list)
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            string serialized = JsonConvert.SerializeObject(list, setting);

            using (StreamWriter sw = new StreamWriter($@"{Directory.GetCurrentDirectory()}\DBFile.json", true))
            {
                sw.WriteLine(serialized);
            }
        }

        public override List<YrLico> Deserialise()
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            List<YrLico> yr = new List<YrLico>();
            using (StreamReader sr = new StreamReader($@"{Directory.GetCurrentDirectory()}\DBFile.json"))
            {
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    yr = (List<YrLico>)serializer.Deserialize(sr, typeof(List<YrLico>));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return yr;
        }
    }
}

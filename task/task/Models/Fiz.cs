using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace task.Models
{
    class Fiz : Kontragents<Fiz>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Fiz(string name, string surname, string iin, string author, DateTime creationdate) : base(iin, author, creationdate)
        {
            Name = name;
            Surname = surname;
        }

        public Fiz() : base(string.Empty, string.Empty, DateTime.Now)
        {

        }
        public override void Write(List<Fiz> list)
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

        public override List<Fiz> Deserialise()
        {
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
            List<Fiz> fz = new List<Fiz>();
            using (StreamReader sr = new StreamReader($@"{Directory.GetCurrentDirectory()}\DBFile.json"))
            {
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    fz = (List<Fiz>)serializer.Deserialize(sr, typeof(List<Fiz>));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return fz;
        }
    }
}

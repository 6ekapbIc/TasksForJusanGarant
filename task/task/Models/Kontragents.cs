using System;
using System.Collections.Generic;

namespace task.Models
{
    public abstract class Kontragents<T>
    {
        public string Id { get; set; }
        public string IIN { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string Author { get; set; }

        public Kontragents(string iin, string author, DateTime date)
        {
            IIN = iin;
            DateOfCreation = date;
            Author = author;
        }

        public abstract void Write(List<T> k);
        public abstract List<T> Deserialise();
    }
}

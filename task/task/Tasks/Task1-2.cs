using System;
using task.Models;

namespace task.Tasks
{
    class Task1_2
    {
        public static void Serialize(dynamic k)
        {
            Object obj = k;
            string name = obj.GetType().GenericTypeArguments[0].ToString();

            Fiz z = new Fiz();
            string namefiz = z.GetType().Name;

            YrLico yr = new YrLico();
            string nameyr = yr.GetType().Name;

            if (name.Contains(namefiz))
                z.Write(k);

            if (name.Contains(nameyr))
                yr.Write(k);
        }

        public static dynamic Deserialize(dynamic k)
        {
            Object obj = k;
            string name = obj.GetType().Name;

            Fiz z = new Fiz();
            string namefiz = z.GetType().Name;

            YrLico yr = new YrLico();
            string nameyr = yr.GetType().Name;

            if (name.Contains(namefiz))
                return z.Deserialise();
            else
                return yr.Deserialise();
        }
    }
}

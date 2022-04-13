using System;
using System.Collections.Generic;
using System.Linq;
using task.Models;
using task.Tasks;

namespace task
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DataSeed
            List<Fiz> fiz = new List<Fiz>();
            fiz.Add(new Fiz("fiz1", "sur1", "1", "compadmin", DateTime.Now));
            fiz.Add(new Fiz("fiz2", "sur2", "2", "compadmin", DateTime.Now));
            fiz.Add(new Fiz("fiz3", "sur3", "3", "compadmin", DateTime.Now));
            fiz.Add(new Fiz("fiz4", "sur4", "4", "compadmin", DateTime.Now));
            fiz.Add(new Fiz("fiz5", "sur5", "5", "compadmin", DateTime.Now));

            List<YrLico> yr = new List<YrLico>();
            yr.Add(new YrLico("org1", "6", "compadmin", DateTime.Now, fiz.GetRange(0, 1)));
            yr.Add(new YrLico("org2", "7", "compadmin", DateTime.Now, fiz.GetRange(0, 3)));
            yr.Add(new YrLico("org3", "8", "compadmin", DateTime.Now, fiz.GetRange(0, 4)));
            yr.Add(new YrLico("org4", "9", "compadmin", DateTime.Now, fiz.GetRange(1, 4)));
            yr.Add(new YrLico("org5", "10", "compadmin", DateTime.Now, fiz.GetRange(1, 2)));

            List<Fiz> emptfiz = new List<Fiz>();
            List<YrLico> emptyr = new List<YrLico>();

            Fiz fiz1 = new Fiz();
            YrLico yr1 = new YrLico();
            #endregion

            #region Task 1 - 2
            Task1_2.Serialize(fiz);
            Task1_2.Serialize(yr);

            emptfiz = Task1_2.Deserialize(fiz1);
            emptyr = Task1_2.Deserialize(yr1);
            #endregion

            #region Task 3
            fiz = fiz.OrderBy(x => x.Name).ThenBy(x => x.Surname).ThenBy(x => x.IIN).ToList();
            yr = yr.OrderBy(x => x.NameOfOrganization).ThenBy(x => x.DateOfCreation).ToList();
            #endregion

            #region Task 4-5
            emptyr = yr.OrderByDescending(x => x.fizs.Count).ToList();
            #endregion

        }
    }
}

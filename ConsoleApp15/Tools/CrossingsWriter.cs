using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CrossingsSearcher.Tools
{
    public class CrossingsWriter
    {
        private string _filePath;

        private List<Vacation> _withCrossings;
        private List<Vacation> _withoutCrossings;

        public CrossingsWriter(List<Vacation> vacations, Vacation newVacation)
        {
            _filePath = Environment.CurrentDirectory + @"\Пересечения Отпусков " + newVacation.StartDate.ToShortDateString() + "-" + newVacation.EndDate.ToShortDateString() + ".txt";

            _withCrossings = VacationComparator.GetCrossings(vacations, newVacation);
            _withoutCrossings = new List<Vacation>();

            foreach (var v in vacations)
            {
                if (!_withCrossings.Contains(v)) _withoutCrossings.Add(v);
            }
        }

        public void WriteFile()
        {
            using(var fs = new FileStream(_filePath, FileMode.Create))
            {
                using(var sw = new StreamWriter(fs))
                {
                    // Получаем список пользователей, младше 30
                    var youngerThirtyVacations = from v in _withCrossings
                                                 where v.User.Age < 30
                                            select v;
                    // Получаем список пользователей, старше 30 и младше 50
                    var youngerFiftyVacations = from v in _withCrossings
                                                where v.User.Age >= 30 && v.User.Age < 50
                                            select v;
                    // Получаем список пользователей, старше 50
                    var olderFiftyVacations = from v in _withCrossings
                                              where v.User.Age >= 50
                                            select v;

                    sw.WriteLine("Пересечение отпуска с сотрудниками, моложе 30:");
                    foreach (var v in youngerThirtyVacations)
                    {
                        sw.WriteLine("{0} - {1} - {2} - {3}", v.StartDate.ToShortDateString(), v.EndDate.ToShortDateString(), v.User.FullName, v.User.Age);
                    }

                    sw.WriteLine("\nПересечение отпуска с сотрудниками, старше 30 моложе 50:");
                    foreach (var v in youngerFiftyVacations)
                    {
                        sw.WriteLine("{0} - {1} - {2} - {3}", v.StartDate.ToShortDateString(), v.EndDate.ToShortDateString(), v.User.FullName, v.User.Age);
                    }

                    sw.WriteLine("\nПересечение отпуска с сотрудниками, старше 50:");
                    foreach (var v in olderFiftyVacations)
                    {
                        sw.WriteLine("{0} - {1} - {2} - {3}", v.StartDate.ToShortDateString(), v.EndDate.ToShortDateString(), v.User.FullName, v.User.Age);
                    }

                    sw.WriteLine("\nОтпуска без пересечения:");
                    foreach (var v in _withoutCrossings)
                    {
                        sw.WriteLine("{0} - {1} - {2} - {3}", v.StartDate.ToShortDateString(), v.EndDate.ToShortDateString(), v.User.FullName, v.User.Age);
                    }
                }
            }
        }
    }
}

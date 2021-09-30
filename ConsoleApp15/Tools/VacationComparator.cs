using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher.Tools
{
    public static class VacationComparator
    {
        public static List<Vacation> GetCrossings(List<Vacation> vacations, Vacation newVacation)
        {
            List<Vacation> crossings = new List<Vacation>();

            foreach (var v in vacations)
            {
                if ((newVacation.StartDate >= v.StartDate && newVacation.StartDate <= v.EndDate) ||
                        (newVacation.EndDate >= v.StartDate && newVacation.StartDate <= v.EndDate))
                {
                    crossings.Add(v);
                }
            }

            return crossings;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher
{
    public class Vacation
    {
        /// <summary>
        /// Дата начала отпуска
        /// </summary>
        public DateTime StartDate { get; private set; }
        /// <summary>
        /// Дата окончания отпуска
        /// </summary>
        public DateTime EndDate { get; private set; }
        /// <summary>
        /// Пользователь с отпуском
        /// </summary>
        public User User { get; private set; }

        public Vacation(DateTime startDate, User user, int leavePeriod) : this(startDate, leavePeriod)
        {
            User = user;
        }

        public Vacation(DateTime startDate, int leavePeriod)
        {
            StartDate = startDate;
            EndDate = StartDate.AddDays(leavePeriod);
        }

        public Vacation(DateTime startDate, User user, DateTime endDate) : this(startDate, endDate)
        {
            User = user;
        }

        public Vacation(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }


        public override string ToString()
        {
            return string.Format("{0} {1} {2}", StartDate.ToShortDateString(), EndDate.ToShortDateString(), User.ToString());
        }
    }
}

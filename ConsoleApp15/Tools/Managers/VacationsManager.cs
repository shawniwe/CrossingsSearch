using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher.Tools.Managers
{
    public class VacationsManager : DefaultManager<Vacation>
    {
        public VacationGenerator Generator { get; private set; }
        private CrossingsWriter _crossingsWriter;

        public VacationsManager() : base()
        {
            Generator = new VacationGenerator();
        }
        /// <summary>
        /// Генератор случайного отпуска + запись его в список менеджера
        /// </summary>
        public Vacation Generate(User user, int period)
        {
            Generator.VacationUser = user;
            Generator.VacationLeavePeriod = period;
            
            var vacation = Generator.GenerateObject();
            AddItems(vacation);

            return vacation;
        }
        /// <summary>
        /// Запись пересечений в файл
        /// </summary>
        public bool WriteCrossings(Vacation newVacation)
        {
            try
            {
                _crossingsWriter = new CrossingsWriter(_items, newVacation);
                _crossingsWriter.WriteFile();
            }
            catch { return false; }

            return true;
        }
    }
}

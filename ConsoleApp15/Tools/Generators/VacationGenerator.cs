using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher.Tools
{
    public class VacationGenerator : IGenerator<Vacation>
    {
        /// <summary>
        /// Длительность отпуска
        /// </summary>
        public int VacationLeavePeriod { get; set; }
        /// <summary>
        /// Пользователь, которому принадлежит отпуск
        /// </summary>
        public User VacationUser { get; set; }

        /// <summary>
        /// Рандомайзер
        /// </summary>
        private static Random _rnd;

        public VacationGenerator()
        {
            _rnd = new Random();
            //Стандартная длительность отпуска - 7 дней
            VacationLeavePeriod = 7;
        }
        /// <summary>
        /// Генерация случайного объекта класса Vacation (Отпуск)
        /// </summary>
        public Vacation GenerateObject()
        {
            // Генерируем случайный месяц
            int randomMonth = _rnd.Next(1, 12);
            // Генерируем случай день
            int randomDay = _rnd.Next(1, DateTime.DaysInMonth(DateTime.Now.Year, randomMonth) + 1);
            // Записываем дату начала отпуска
            DateTime randomStartDate = new DateTime(DateTime.Now.Year, randomMonth, randomDay);
            // Возвращаем объект отпуск
            return new Vacation(randomStartDate, VacationUser, VacationLeavePeriod);
        }
    }
}

using CrossingsSearcher.Tools;
using CrossingsSearcher.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher
{
    class Program
    {
        static UsersManager usersManager;
        static VacationsManager vacationManager;

        static int UsersCount = 100;

        static void Main(string[] args)
        {
            // Инициализируем списки "пользователи" и "отпуски"
            usersManager = new UsersManager();
            vacationManager = new VacationsManager();

            // Генерируем пользователей и отпуски
            for (int i = 0; i < UsersCount; i++)
            {
                // Генерация пользователя
                User user = usersManager.Generate();

                // Генерация отпусков для пользователя
                vacationManager.Generate(user, 7);
                vacationManager.Generate(user, 7);
                vacationManager.Generate(user, 14);
            }

            Console.WriteLine("Сгенерировано {0} пользователей", UsersCount);

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            // Бесконечный цикл для ввода даты начала нового отпуска
            while(true)
            {
                Console.Write("Введите дату начала нового отпуска в формате \"ДД.ММ\" (год указывается автоматически!): ");
                string startDateStr = Console.ReadLine().Trim(' '); // обрезаем случайно поставленные пробелы

                if (startDateStr.Any(x => char.IsLetter(x))) // проверяем строку на наличие букв
                {
                    Console.WriteLine("[ОШИБКА]: Дата начала отпуска не должна содержать букв!");
                    continue;
                }

                string[] startDateSplitted = startDateStr.Split('.'); // разделяем строку по точке

                if (startDateSplitted.Length < 2) // если получилось меньше 2-х элементов, выводим ошибку
                {
                    Console.WriteLine("[ОШИБКА]: Неверный формат даты.");
                    continue;
                }

                try // пробуем записать получившуюся дату
                {
                    startDate = new DateTime(DateTime.Now.Year, int.Parse(startDateSplitted[1]), int.Parse(startDateSplitted[0]));
                }
                catch // в случае, если дата указана неверно (например 30.02)
                {
                    Console.WriteLine("[ОШИБКА]: Неверно указана дата.");
                    continue;
                }

                break;
            }

            // Бесконечный цикл для ввода даты конца нового отпуска
            while (true)
            {
                Console.Write("Введите дату окончания нового отпуска в формате \"ДД.ММ\" (год указывается автоматически!): ");
                string endDateStr = Console.ReadLine().Trim(' '); // обрезаем случайно поставленные пробелы

                if (endDateStr.Any(x => char.IsLetter(x))) // проверяем строку на наличие букв
                {
                    Console.WriteLine("[ОШИБКА]: Дата окончания отпуска не должна содержать букв!");
                    continue;
                }

                string[] endDateSplitted = endDateStr.Split('.'); // разделяем строку по точке

                if (endDateSplitted.Length < 2) // если получилось меньше 2-х элементов, выводим ошибку
                {
                    Console.WriteLine("[ОШИБКА]: Неверный формат даты.");
                    continue;
                }

                try // пробуем записать получившуюся дату
                {
                    endDate = new DateTime(DateTime.Now.Year, int.Parse(endDateSplitted[1]), int.Parse(endDateSplitted[0]));
                }
                catch // в случае, если дата указана неверно (например 30.02)
                {
                    Console.WriteLine("[ОШИБКА]: Неверно указана дата.");
                    continue;
                }

                if ((endDate - startDate).Days > 14) // проверяем разницу между датами
                {
                    Console.WriteLine("[ОШИБКА]: Дата окончания отпуска отличается от даты начала отпуска более, чем на 14 дней!\n");
                    continue;
                }
                else if((endDate - startDate).Days < 0)
                {
                    Console.WriteLine("[ОШИБКА]: Даты указаны неверно!\n");
                    continue;
                }

                break;
            }

            // Создаем объект класса Vacation (отпуск) с датами нашего нового отпуска
            var newVacation = new Vacation(startDate, endDate);

            // записываем пересечения в файл
            if(vacationManager.WriteCrossings(newVacation))
            {
                Console.WriteLine("Пересечения успешно записаны в файл!");
            }
            else
            {
                Console.WriteLine("[ОШИБКА]: Пересечения не были записаны в файл.");
            }

            Console.ReadKey();
        }
    }
}
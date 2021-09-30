using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher.Tools
{
    public class UserGenerator : IGenerator<User>
    {
        // Поле статическое, поскольку в противном случае рандомайзер работает некорректно
        private static Random _rnd;

        /// <summary>
        /// Путь к файлу с именами
        /// </summary>
        private string _firstnamesPath = Environment.CurrentDirectory + @"\Data\Names.txt";

        /// <summary>
        /// Путь к файлу с фамилиями
        /// </summary>
        private string _surnamesPath = Environment.CurrentDirectory + @"\Data\Surnames.txt";

        /// <summary>
        /// Путь к файлу с отчествами
        /// </summary>
        private string _patronymicsPath = Environment.CurrentDirectory + @"\Data\Patronymics.txt";

        /// <summary>
        /// Максимальный возраст случайно сгенерированного пользователя
        /// </summary>
        public int MaxAge { get; set; }

        /// <summary>
        /// Минимальный возраст случайно сгенерированного пользователя
        /// </summary>
        public int MinAge { get; set; }
    
        public UserGenerator(int minAge = 65, int maxAge = 18)
        {
            MaxAge = minAge;
            MinAge = maxAge;

            _rnd = new Random();
        }

        /// <summary>
        /// Метод, генерирующий случайного пользователя
        /// </summary>
        public User GenerateObject()
        {
            // Генерация случайного имени пользователя
            string fullName = string.Format("{0} {1} {2}",
                File.ReadAllLines(_surnamesPath)[_rnd.Next(File.ReadAllLines(_surnamesPath).Length)],
                File.ReadAllLines(_firstnamesPath)[_rnd.Next(File.ReadAllLines(_firstnamesPath).Length)],
                File.ReadAllLines(_patronymicsPath)[_rnd.Next(File.ReadAllLines(_patronymicsPath).Length)]);

            // Генерация случайной должности пользователя
            int randomPosition = _rnd.Next(Enum.GetValues(typeof(Position)).Length);
            Position position = (Position)randomPosition;

            // Генерация случайного возраста пользователя
            int age = _rnd.Next(MinAge, MaxAge + 1);

            return new User(fullName, position, age);
        }
    }
}

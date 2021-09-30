using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher
{
    public class User
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FullName { get; private set; }
        /// <summary>
        /// Должностть пользователя
        /// </summary>
        private Position _position;
        /// <summary>
        /// Возраст пользователя
        /// </summary>
        public int Age { get; private set; }

        public User() { }

        public User(string fullName, Position position, int age)
        {
            FullName = fullName;
            _position = position;
            Age = age;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FullName, _position, Age);
        }
    }
}

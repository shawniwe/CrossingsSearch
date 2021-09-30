using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingsSearcher.Tools.Managers
{
    public class UsersManager : DefaultManager<User>
    {
        public UserGenerator Generator { get; private set; }

        public UsersManager()
        {
            Generator = new UserGenerator();
        }
        /// <summary>
        /// Генератор случайного пользователя + запись его в список менеджера
        /// </summary>
        public User Generate()
        {
            User user = Generator.GenerateObject();
            AddItems(user);

            return user;
        }
    }
}

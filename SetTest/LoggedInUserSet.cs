using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetTest
{
    public class LoggedInUserSet
    {
        HashSet<User> _users;
        public LoggedInUserSet()
        {
            _users = new HashSet<User>();
        }
        //利用集合的特性，在增加删除的操作中，如果失败后会返回false 这样不用判断集合中是否存在该对象。
        public bool UserAuthenticated(User user)
        {
            if (_users.Count<30)
            {
                return _users.Add(user);
            }
            return false;
        }
        public void UserLoggedOut(User user)
        {
            _users.Remove(user);
        }
    }

    public class User
    {
        public string Name { get; set; }
    }
}

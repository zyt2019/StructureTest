﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWeb
{
   public  class LoggedInUserList
    {
        List<User> _users;
        public LoggedInUserList()
        {
            _users = new List<User>();
        }
        public bool CanAddUser(User user)
        {
            if (_users.Contains(user)||_users.Count>=30)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void UserAuthenticated(User user)
        {
            if (this.CanAddUser(user))
            {
                _users.Add(user);
            }
        }
        public void UserLoggedOut(User user)
        {
            _users.Remove(user);
        }
    }
}

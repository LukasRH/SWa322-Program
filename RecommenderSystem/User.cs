﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecommenderSystem
{
    class User : Person
    {
        private string _userName;
        private string _password;

        public User(string firstName, string lastName, string userName, string password) : base(firstName, lastName)
        {
            _userName = userName;
            _password = password;
        }
    }
}

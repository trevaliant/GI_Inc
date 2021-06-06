using GI_Inc.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GI_Inc
{
    public partial class User : user
    { 


        public User()
        {
            userName = "test";
            password = "test";
        }

        public User(string _username, string _password)
        {
            userName = _username;
            password = _password;
        }
    }
}

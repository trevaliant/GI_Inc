using GI_Inc.DAL;

namespace GI_Inc
{
    public partial class Agent : agent
    {


        public Agent()
        {

        }

        public Agent(string _username, string _password)
        {
            userName = _username;
            password = _password;
        }
    }
}

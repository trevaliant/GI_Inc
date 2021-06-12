using GI_Inc.DAL;
using GI_Inc.DataSources;

namespace GI_Inc
{
    public partial class Agents : agent
    {


        public Agents()
        {

        }

        public Agents(string _username, string _password)
        {
            userName = _username;
            password = _password;
        }
    }
}

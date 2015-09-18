using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client
{
    public class ConnectionConfiguration
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Uri { get; set; }

        public AuthenticationMechanism AuthenticationMechanism { get; set; }

        public ConnectionConfiguration()
        {
            AuthenticationMechanism = AuthenticationMechanism.Default;
        }
    }
}

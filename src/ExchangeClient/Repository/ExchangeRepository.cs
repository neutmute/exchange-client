using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using Exchange.Client.Commands;
using Exchange.Client.Domain;

namespace Exchange.Client.Repository
{
    class ExchangeRepository
    {
        private readonly ConnectionConfiguration _configuration;
        private WSManConnectionInfo __connection;

        private WSManConnectionInfo Connection
        {
            get
            {
                if (__connection == null)
                {
                    __connection = GetConnection();
                }
                return __connection;
            }
        }

        public ExchangeRepository(ConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        private WSManConnectionInfo GetConnection()
        {
            // Encrypt password using SecureString class
            var securePassword = _configuration.Password.ToSecureString();

            var credential = new PSCredential(_configuration.Username, securePassword);
            const string shellUri = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
            var fullUri = new Uri(_configuration.Uri);

            var connectionInfo = new WSManConnectionInfo(fullUri, shellUri, credential);

            connectionInfo.AuthenticationMechanism = _configuration.AuthenticationMechanism;
            connectionInfo.MaximumConnectionRedirectionCount = 2;

            return connectionInfo;
        }


        public ExecutionResult Execute(PowerShellCommand command)
        {
            var result = new ExecutionResult();
            // Create runspace on remote Exchange server
            using (Runspace runspace = RunspaceFactory.CreateRunspace(Connection))
            {
                runspace.Open();

                using (PowerShell ps = PowerShell.Create())
                {
                    ps.Runspace = runspace;

                    ps.Commands.AddCommand(command.ToCommand());

                    result.Results = ps.Invoke();

                    if (ps.Streams.Error.Count > 0)
                    {
                        foreach (ErrorRecord error in ps.Streams.Error)
                        {
                            var powershellError = new PowershellError(error);
                            result.Errors.Add(powershellError);
                        }
                    }
                }
            }

            return result;
        }
    }
}

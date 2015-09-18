using System.Collections.Generic;
using System.Management.Automation.Runspaces;

namespace Exchange.Client.Commands
{
    abstract class PowerShellCommand
    {
        protected abstract string CommandName { get; }

        protected virtual List<CommandParameter> GetParameters()
        {
            return new List<CommandParameter>();
        }

        internal Command ToCommand()
        {
            var command = new Command(CommandName);
            var parameters = GetParameters();
            parameters.ForEach(command.Parameters.Add);
            return command;
        }


    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using Exchange.Client.Domain;
using Exchange.Client.Repository;

namespace Exchange.Client.Commands
{
    class NewDistributionGroupCommand : PowerShellCommandWithResult<CommandResponse>
    {
        public string Name { get; set; }

        protected override string CommandName => "New-DistributionGroup";
        
        protected override List<CommandParameter> GetParameters()
        {
            return new List<CommandParameter> { new CommandParameter("Name", Name) };
        }
    }
    
}

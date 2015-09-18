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
        public DistributionGroup DistributionGroup { get; set; }

        protected override string CommandName => "New-DistributionGroup";
        
        protected override List<CommandParameter> GetParameters()
        {
            var parameters = new List<CommandParameter>();
            parameters.Add("Name", DistributionGroup.Name);
            parameters.Add("DisplayName", DistributionGroup.DisplayName);
            parameters.Add("Alias", DistributionGroup.Alias);
            parameters.Add("Notes", DistributionGroup.Notes);
            parameters.Add("OrganizationalUnit", DistributionGroup.OrganizationalUnit);
            return parameters;
        }

        protected override void DoPopulateResponse(CommandResponse response, ExecutionResult executionResult)
        {
            foreach (var result in executionResult.Results)
            {

            }
        }
    }
    
}

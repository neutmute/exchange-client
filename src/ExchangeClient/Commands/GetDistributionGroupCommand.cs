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
    class GetDistributionGroupCommand : PowerShellCommandWithResult<GetDistributionGroupResponse>
    {
        public string Identity { get; set; }

        protected override string CommandName => "Get-DistributionGroup";
        
        protected override List<CommandParameter> GetParameters()
        {
            return new List<CommandParameter> { new CommandParameter("Identity", Identity) };
        }

        protected override void DoPopulateResponse(GetDistributionGroupResponse response, ExecutionResult executionResult)
        {
            foreach (var result in executionResult.Results)
            {
                var group = PropertyMapper.Map<DistributionGroup>(result);
                response.DistributionGroup = group;
            }
        }
    }


    public class GetDistributionGroupResponse : CommandResponse
    {
        public DistributionGroup DistributionGroup { get; set; }

        public bool HasDistributionGroup => DistributionGroup != null;
    }
}

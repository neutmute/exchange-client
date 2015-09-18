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
    /// <summary>
    /// https://technet.microsoft.com/en-us/library/aa998856%28v=exchg.150%29.aspx
    /// </summary>
    class NewDistributionGroupCommand : PowerShellCommandWithResult<NewDistributionGroupResponse>
    {
        public DistributionGroup DistributionGroup { get; set; }

        protected override string CommandName => "New-DistributionGroup";
        
        protected override List<CommandParameter> GetParameters()
        {
            var parameters = new List<CommandParameter>
            {
                {"Name",        DistributionGroup.Name},
                {"DisplayName", DistributionGroup.DisplayName},
                {"Alias",       DistributionGroup.Alias},
                {"Notes",       DistributionGroup.Notes},
                {"OrganizationalUnit", DistributionGroup.OrganizationalUnit}
            };
            return parameters;
        }

        protected override void DoPopulateResponse(NewDistributionGroupResponse response, ExecutionResult executionResult)
        {
            foreach (var result in executionResult.Results)
            {
                var group = PropertyMapper.Map<DistributionGroup>(result);
                response.DistributionGroup = group;
            }
        }

    }

    public class NewDistributionGroupResponse : GetDistributionGroupResponse
    {
    }
}

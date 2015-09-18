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
    class GetDistributionGroupMemberCommand : PowerShellCommandWithResult<GetDistributionGroupMemberResponse>
    {
        public string Identity { get; set; }

        protected override string CommandName => "Get-DistributionGroupMember";
        
        protected override List<CommandParameter> GetParameters()
        {
            return new List<CommandParameter> { new CommandParameter("Identity", Identity) };
        }

        protected override void DoPopulateResponse(GetDistributionGroupMemberResponse response, ExecutionResult executionResult)
        {
            foreach (var result in executionResult.Results)
            {
                var member = PropertyMapper.Map<DistributionGroupMember>(result);
                response.Members.Add(member);
            }
        }
    }


    public class GetDistributionGroupMemberResponse : CommandResponse
    {
        public List<DistributionGroupMember> Members { get; set; }

        public GetDistributionGroupMemberResponse()
        {
            Members = new List<DistributionGroupMember>();
        }

    }
}

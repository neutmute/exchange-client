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
    class AddDistributionGroupMemberCommand : PowerShellCommandWithResult<CommandResponse>
    {
        public string Identity { get; set; }
        public string Member { get; set; }

        protected override string CommandName => "Add-DistributionGroupMember";
        
        protected override List<CommandParameter> GetParameters()
        {
            var parameters = new List<CommandParameter>();
            parameters.Add("Identity", Identity);
            parameters.Add("Member", Member);
            return parameters;
        }
    }
    
}

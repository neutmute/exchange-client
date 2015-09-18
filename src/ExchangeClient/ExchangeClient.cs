using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Exchange.Client.Commands;
using Exchange.Client.Domain;
using Exchange.Client.Repository;

namespace Exchange.Client
{
    /// <summary>
    /// http://stackoverflow.com/questions/1469791/powershell-v2-remoting-how-do-you-enable-unencrypted-traffic
    /// </summary>
    public class ExchangeClient
    {
        private readonly ExchangeRepository _repository;

        public ExchangeClient(ConnectionConfiguration configuration)
        {
            _repository = new ExchangeRepository(configuration);
        }

        public GetDistributionGroupMemberResponse GetDistributionGroupMember(string name)
        {

            var command = new GetDistributionGroupMemberCommand();
            command.Identity = name;

            var rawResult = _repository.Execute(command);

            var results = command.ProcessResult(rawResult);
            return results;
        }

        public GetDistributionGroupResponse GetDistributionGroup(string name)
        {
            var command = new GetDistributionGroupCommand();
            command.Identity = name;

            var rawResult = _repository.Execute(command);

            var results = command.ProcessResult(rawResult);
            return results;
        }

        public CommandResponse NewDistributionGroup(string name)
        {
            var command = new NewDistributionGroupCommand();
            command.Name = name;

            var rawResult = _repository.Execute(command);

            var results = command.ProcessResult(rawResult);
            return results;
        }
    }
}

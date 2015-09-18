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
    public class ExchangeClient : IExchangeClient
    {
        private readonly ExchangeRepository _repository;

        public ExchangeClient(ConnectionConfiguration configuration)
        {
            _repository = new ExchangeRepository(configuration);
        }

        public CommandResponse RemoveDistributionGroupMember(string identity, string member)
        {
            var command = new RemoveDistributionGroupMemberCommand();
            command.Identity = identity;
            command.Member = member;

            var rawResult = _repository.Execute(command);

            var results = command.ProcessResult(rawResult);
            return results;
        }

        public CommandResponse AddDistributionGroupMember(string identity, string member)
        {
            var command = new AddDistributionGroupMemberCommand();
            command.Identity = identity;
            command.Member = member;

            var rawResult = _repository.Execute(command);

            var results = command.ProcessResult(rawResult);
            return results;
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

        public CommandResponse NewDistributionGroup(DistributionGroup group)
        {
            var command = new NewDistributionGroupCommand();
            command.DistributionGroup = group;

            var rawResult = _repository.Execute(command);

            var results = command.ProcessResult(rawResult);
            return results;
        }
    }
}

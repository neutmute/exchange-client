using Exchange.Client.Domain;

namespace Exchange.Client.Commands
{
    abstract class PowerShellCommandWithResult<TResponse>: PowerShellCommand where TResponse: CommandResponse, new() 
    {
        internal TResponse ProcessResult(ExecutionResult result)
        {
            var response = new TResponse();
            DoPopulateResponse(response, result);
            return response;
        }

        protected virtual void DoPopulateResponse(TResponse response, ExecutionResult result)
        {
        }
    }
}
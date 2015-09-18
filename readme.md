# Exchange Client #
[Exchange Management Shell](https://msdn.microsoft.com/en-us/library/cc505910.aspx) wrapper for .NET

Methods implemented can be found [here](https://github.com/neutmute/exchange-client/blob/master/src/ExchangeClient/IExchangeClient.cs)

## Usage ##
Example usage

   		private ConnectionConfiguration GetConfig()
        {
            var config = new ConnectionConfiguration();
            config.Username = "theuser";
            config.Password = "supersecret";
            config.Uri = "http://YourExchangeServer/powershell";
            return config;
        }

        private void ExampleUsage()
        {
            var client = new ExchangeClient(GetConfig());
            var output = client.GetDistributionGroup(dlEposUsers);
        }


## Notes ##

Client may require [AllowUnencrypted set to true](http://stackoverflow.com/questions/1469791/powershell-v2-remoting-how-do-you-enable-unencrypted-traffic)

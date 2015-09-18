using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exchange.Client.Repository
{

    /// <summary>
    /// Simple automapper
    /// </summary>
    class PropertyMapper
    {
        public static TOutput Map<TOutput>(PSObject input) where TOutput:new()
        {
            var outputInstance = new TOutput();

            var properties = outputInstance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var outputProperty in properties)
            {
                var inputProp = input.Properties[outputProperty.Name];
                if (inputProp.IsGettable)
                {
                    if (outputProperty.CanWrite)
                    {
                        outputProperty.SetValue(outputInstance, inputProp.Value, null);
                    }
                }
            }

            return outputInstance;
        }
    }
}

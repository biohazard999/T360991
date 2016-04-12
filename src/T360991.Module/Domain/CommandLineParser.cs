using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using T360991.Module.Model;

namespace T360991.Module.Domain
{
    public class CommandLineParser
    {
        private IModelApplication model;

        public CommandLineParser(IModelApplication model)
        {
            this.model = model;
        }

        public IModelNavigationItem Parse(string[] commandlineArguments)
        {
            var commandLineOptions = ((IModelApplicationCommandlineOptions) model);

            if (commandlineArguments.Length > 0)
            {
                var keyArgument = commandlineArguments.First().ToLower();

                var item = commandLineOptions.CommandlineOptions.FirstOrDefault(m => m.Argument.Equals(keyArgument, StringComparison.InvariantCultureIgnoreCase));

                return item?.NavigationItem;
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;

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
            var navigationItems = ((IModelApplicationNavigationItems)model);

            return navigationItems.NavigationItems.Items["Default"].Items.First();
        }
    }
}

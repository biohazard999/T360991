using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace T360991.Module
{
    public class T360991Module : ModuleBase
    {
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            return new ModuleTypeList(typeof(SystemModule));
        }
    }
}

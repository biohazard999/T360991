using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;

namespace T360991.Module.Win
{
    public class T360991WindowsFormsModule : ModuleBase
    {
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            return new ModuleTypeList(
                typeof(SystemModule),
                typeof(SystemWindowsFormsModule),
                typeof(T360991Module)
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Objects;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;

namespace T360991.Module
{
    public class T360991Module : ModuleBase
    {
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            return new ModuleTypeList(
                typeof(SystemModule),
                typeof(BusinessClassLibraryCustomizationModule)
                );
        }

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return new[]
            {
                typeof(Event),
                typeof(Person)
            };
        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            return Type.EmptyTypes;
        }

        protected override void RegisterEditorDescriptors(List<EditorDescriptor> editorDescriptors)
        {
        }
    }
}

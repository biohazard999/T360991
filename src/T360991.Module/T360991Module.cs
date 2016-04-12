using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using T360991.Module.Model;

namespace T360991.Module
{
    public class T360991Module : ModuleBase
    {
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            return new ModuleTypeList(typeof(SystemModule));
        }

        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelApplication, IModelApplicationCommandlineOptions>();
        }

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return Type.EmptyTypes;
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

using System;
using System.Collections.Generic;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Persistent.BaseImpl;

namespace Para.ExpressApp.CommandLineLauncher.Win
{
    public class TestModule : ModuleBase
    {
        protected override ModuleTypeList GetRequiredModuleTypesCore()
        {
            return new ModuleTypeList(
                typeof(SystemModule),
                typeof(SystemWindowsFormsModule),
                typeof(CommandLineLauncherWindowsFormsModule));
        }

        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return new[]
            {
                typeof(Event),
                typeof(Person),
            };
        }

        protected override IEnumerable<Type> GetDeclaredControllerTypes()
        {
            return Type.EmptyTypes;
        }

        protected override void RegisterEditorDescriptors(List<EditorDescriptor> editorDescriptors)
        {
            
        }

        public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters)
        {
            base.AddGeneratorUpdaters(updaters);
            updaters.Add(new NavigationItemGeneratorUpdater());
            updaters.Add(new CommandlineOptionsGeneratorUpdater());
        }
    }
}
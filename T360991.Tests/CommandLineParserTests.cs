using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;
using Shouldly;
using T360991.Module.Domain;
using Xunit;

namespace T360991.Tests
{
    public class NavigationItemGeneratorUpdater : ModelNodesGeneratorUpdater<NavigationItemNodeGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            var rootNavigationItems = (IModelRootNavigationItems)node;
            
            var viewId = ModelNodeIdHelper.GetListViewId(typeof(Event));

            ShowNavigationItemController.GenerateNavigationItem(rootNavigationItems.Application, new ViewShortcut(viewId, null), "Default");
        }
    }

    public class TestModule : ModuleBase
    {
        protected override IEnumerable<Type> GetDeclaredExportedTypes()
        {
            return new[] {typeof(Event)};
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
        }
    }

    public class CommandLineParserTests : IDisposable
    {
        private TestApplication _application;

        public CommandLineParserTests()
        {
            _application = new TestApplication();

            _application.Modules.Add(new TestModule());

            _application.Setup();
        }

        [Theory]
        [Xunit.MemberData(nameof(ParserTestData))]
        public void Parse(string[] arguments, string navigationItemId)
        {
            var parser = new CommandLineParser(_application.Model);
            var node = parser.Parse(null);

            node.View.Id.ShouldBe(navigationItemId);
        }

        public static IEnumerable<object[]> ParserTestData
        {
            get
            {
                yield return new object[] {new [] { "/Events" }, "Event_ListView"};
            }
        }


        public void Dispose()
        {
            _application?.Dispose();
            _application = null;
        }
    }
}

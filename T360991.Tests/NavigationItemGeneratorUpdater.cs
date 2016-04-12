using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.BaseImpl;
using Para.ExpressApp.CommandLineLauncher.Win.Model;

namespace Para.ExpressApp.CommandLineLauncher.Win
{
    public class NavigationItemGeneratorUpdater : ModelNodesGeneratorUpdater<NavigationItemNodeGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            var rootNavigationItems = (IModelRootNavigationItems)node;

            var mainNode = rootNavigationItems.Items.AddNode<IModelNavigationItem>("Main");

            AddNavItem(mainNode.Items, ModelNodeIdHelper.GetListViewId(typeof(Event)));
            AddNavItem(mainNode.Items, ModelNodeIdHelper.GetListViewId(typeof(Person)));
        }

        private void AddNavItem(IModelNavigationItems node, string id)
        {
            var personItem = node.AddNode<IModelNavigationItem>(id);
            personItem.View = node.Application.Views[id];
        }
    }

    public class CommandlineOptionsGeneratorUpdater : ModelNodesGeneratorUpdater<CommandlineOptionsModelNodesGenerator>
    {
        public override void UpdateNode(ModelNode node)
        {
            var options = (IModelCommandlineOptionsIModelNode)node;
            
            var items = ((IModelApplicationNavigationItems)node.Application).NavigationItems;

            var eventNode = options.AddNode<IModelCommandlineOption>();
            eventNode.Argument = "/Events";
            eventNode.NavigationItem = items.Items["Main"].Items[ModelNodeIdHelper.GetListViewId(typeof(Event))];
            
            var personNode = options.AddNode<IModelCommandlineOption>();
            personNode.Argument = "/People";
            personNode.NavigationItem = items.Items["Main"].Items[ModelNodeIdHelper.GetListViewId(typeof(Person))];
        }
    }
}
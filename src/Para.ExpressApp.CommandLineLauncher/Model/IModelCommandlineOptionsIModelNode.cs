using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;

namespace Para.ExpressApp.CommandLineLauncher.Win.Model
{
    [ImageName("OperatingSystem")]
    [ModelNodesGenerator(typeof(CommandlineOptionsModelNodesGenerator))]
    public interface IModelCommandlineOptionsIModelNode : IModelNode, IModelList<IModelCommandlineOption>
    {
    }
}
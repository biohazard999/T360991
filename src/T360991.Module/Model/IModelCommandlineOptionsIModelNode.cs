using System.ComponentModel;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;

namespace T360991.Module.Model
{
    [ImageName("OperatingSystem")]
    [ModelNodesGenerator(typeof(CommandlineOptionsModelNodesGenerator))]
    public interface IModelCommandlineOptionsIModelNode : IModelNode, IModelList<IModelCommandlineOption>
    {
        [DefaultValue(true)]
        [Description("Specifies if only a single instance of the application should be allowed")]
        bool SingeInstance { get; set; }
    }
}
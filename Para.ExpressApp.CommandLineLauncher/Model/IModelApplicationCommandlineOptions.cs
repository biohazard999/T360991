using DevExpress.ExpressApp.Model;

namespace Para.ExpressApp.CommandLineLauncher.Win.Model
{
    public interface IModelApplicationCommandlineOptions : IModelNode
    {
        IModelCommandlineOptionsIModelNode CommandlineOptions { get; }
    }
}

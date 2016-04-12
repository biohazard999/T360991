using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;

namespace Para.ExpressApp.CommandLineLauncher.Win.Model
{
    public interface IModelCommandlineOption : IModelNode
    {
        [Required]
        string Argument { get; set; }

        [Required]
        [DataSourceProperty("Application.NavigationItems.AllItems")]
        IModelNavigationItem NavigationItem { get; set; }
    }
}
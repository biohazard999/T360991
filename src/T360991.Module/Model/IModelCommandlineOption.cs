using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;

namespace T360991.Module.Model
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
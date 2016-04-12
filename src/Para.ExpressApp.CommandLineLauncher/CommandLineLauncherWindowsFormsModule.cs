using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win;
using Para.ExpressApp.CommandLineLauncher.Win.Controllers;
using Para.ExpressApp.CommandLineLauncher.Win.Domain;
using Para.ExpressApp.CommandLineLauncher.Win.Model;

namespace Para.ExpressApp.CommandLineLauncher.Win
{
    public class CommandLineLauncherWindowsFormsModule : ModuleBase
    {
        public SingleInstance Mutex { get; set; }

        [DefaultValue(true)]
        [Description("Specifies if only a single instance of the application should be allowed")]
        public bool OnlySingeInstance { get; set; } = true;

        public string[] CommandLineArguments { get; set; }

        public CommandLineLauncherWindowsFormsModule()
        {
            CommandLineArguments = SingleInstance.Arguments;
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
            return new[]
            {
                typeof(ProcessCommandlineShortcutWindowController)
            };
        }

        protected override void RegisterEditorDescriptors(List<EditorDescriptor> editorDescriptors)
        {
        }

        public override void Setup(XafApplication application)
        {
            base.Setup(application);

            application.SettingUp += Application_SettingUp;
           
        }

        private void Application_SettingUp(object sender, SetupEventArgs e)
        {
            if (OnlySingeInstance && Application is WinApplication)
            {
                Mutex = new SingleInstance(Application.ApplicationName);

                if (!Mutex.IsFirstInstance)
                {
                    var winApplication = (Application as WinApplication);

                    winApplication.SplashScreen?.Stop();
                    Mutex.PassArgumentsToFirstInstance();
                    winApplication.Exit();
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if(disposing)
                Mutex?.Dispose();
        }
    }
}

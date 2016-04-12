using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.SystemModule;
using Para.ExpressApp.CommandLineLauncher.Win.Domain;
using Para.ExpressApp.CommandLineLauncher.Win.Utils;

namespace Para.ExpressApp.CommandLineLauncher.Win.Controllers
{
    public class ProcessCommandlineShortcutWindowController : WindowController
    {
        CommandLineLauncherWindowsFormsModule Module => Application.Modules.OfType<CommandLineLauncherWindowsFormsModule>().First();

        public ProcessCommandlineShortcutWindowController()
        {
            TargetWindowType = WindowType.Main;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            ProcessCommandlineShortcut(Module.CommandLineArguments);

            if (Module.Mutex.IsFirstInstance)
            {
                Module.Mutex.ArgumentsReceived += Mutex_ArgumentsReceived;
                Module.Mutex.ListenForArgumentsFromSuccessiveInstances();
            }
        }

        private void Mutex_ArgumentsReceived(object sender, ArgumentsReceivedEventArgs e)
        {
            var form = (Application?.MainWindow as WinWindow)?.Form;
            if (form != null)
            {
                form.SafeInvoke(() => ProcessCommandlineShortcut(e.Args));
            }
        }

        private void ProcessCommandlineShortcut(string[] commandLineArguments)
        {
            var parser = new CommandLineParser(Application.Model);

            var item = parser.Parse(commandLineArguments);

            if (item != null)
            {
                Frame.GetController<WinShowStartupNavigationItemController>().Active[nameof(ProcessCommandlineShortcutWindowController)] = false;

                var controller = Frame.GetController<ShowNavigationItemController>();

                var shortCut = new ViewShortcut(item.View.Id, null);

                var choiceActionItem = new ChoiceActionItem("CommandLineArgument", shortCut);

                controller.ShowNavigationItemAction.DoExecute(choiceActionItem);
            }
        }
    }
}

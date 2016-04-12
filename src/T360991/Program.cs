using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using T360991.Module;
using T360991.Module.Win;

namespace T360991
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            InMemoryDataStoreProvider.Register();
            
            var application = new WinApplication
            {
                ApplicationName = nameof(T360991),
                SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen(),
                ConnectionString = InMemoryDataStoreProvider.ConnectionString
            };

            application.Modules.Add(new SystemModule());
            application.Modules.Add(new SystemWindowsFormsModule());

            //This is for demo purposes only, so we have some persistent classes and data to play with
            application.Modules.Add(new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule(typeof(Event).Assembly));

            application.Modules.Add(new T360991Module());
            application.Modules.Add(new T360991WindowsFormsModule());

            application.CreateCustomObjectSpaceProvider += (sender, args) =>
            {
                args.ObjectSpaceProvider = new XPObjectSpaceProvider(new ConnectionStringDataStoreProvider(args.ConnectionString));
            };

            application.DatabaseVersionMismatch += (sender, args) =>
            {
                args.Updater.Update();
                args.Handled = true;
            };


            try
            {
                application.Setup();

                application.Start();
            }
            catch (Exception e)
            {
                application.HandleException(e);
            }
        }
    }
}

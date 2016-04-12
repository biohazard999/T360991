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
using T360991.Win;

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

            var application = new T360991WinApplication
            {
                ConnectionString = InMemoryDataStoreProvider.ConnectionString
            };

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

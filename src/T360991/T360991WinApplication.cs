using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Persistent.BaseImpl;
using T360991.Module;
using T360991.Module.Win;

namespace T360991.Win
{
    public class T360991WinApplication : WinApplication
    {
        public T360991WinApplication()
        {

            ApplicationName = nameof(T360991);
            SplashScreen = new DevExpress.ExpressApp.Win.Utils.DXSplashScreen();
                
            Modules.Add(new SystemModule());
            Modules.Add(new SystemWindowsFormsModule());

            //This is for demo purposes only, so we have some persistent classes and data to play with
            Modules.Add(new DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule(typeof(Event).Assembly));

            Modules.Add(new T360991Module());
            Modules.Add(new T360991WindowsFormsModule());
        }
    }
}

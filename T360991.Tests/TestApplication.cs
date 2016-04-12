using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;

namespace Para.ExpressApp.CommandLineLauncher.Win
{
    public class TestApplication : XafApplication
    {
        public TestApplication()
        {
            Modules.Add(new SystemModule());
            Modules.Add(new SystemWindowsFormsModule());
            Modules.Add(new CommandLineLauncherWindowsFormsModule());
        }

        protected override LayoutManager CreateLayoutManagerCore(bool simple)
        {
            return null;
        }

        protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
        {
            args.ObjectSpaceProvider = new NonPersistentObjectSpaceProvider();
        }
    }
}
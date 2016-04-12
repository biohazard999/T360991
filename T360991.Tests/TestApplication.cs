using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;
using T360991.Module;
using T360991.Module.Win;

namespace T360991.Tests
{
    public class TestApplication : XafApplication
    {
        public TestApplication()
        {
            Modules.Add(new SystemModule());
            Modules.Add(new SystemWindowsFormsModule());
            Modules.Add(new T360991Module());
            Modules.Add(new T360991WindowsFormsModule());
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
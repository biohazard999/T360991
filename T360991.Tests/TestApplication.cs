using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Layout;

namespace T360991.Tests
{
    public class TestApplication : XafApplication
    {
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
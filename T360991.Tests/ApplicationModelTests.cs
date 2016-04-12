using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Win.SystemModule;
using Shouldly;
using T360991.Module;
using T360991.Module.Model;
using T360991.Module.Win;
using Xunit;

namespace T360991.Tests
{
    public class ApplicationModelTests : IDisposable
    {
        TestApplication Application { get; set; }

        public ApplicationModelTests()
        {
            Application = new TestApplication();
            Application.Modules.Add(new SystemModule());
            Application.Modules.Add(new SystemWindowsFormsModule());
            Application.Modules.Add(new T360991Module());
            Application.Modules.Add(new T360991WindowsFormsModule());
            Application.Setup();
        }

        [Fact]
        public void ApplicationModelIsOptions()
        {
            var result = Application.Model is IModelApplicationCommandlineOptions;
            result.ShouldBe(true);
        }

        [Fact]
        public void DefaultValueForSingleInstanceIsTrue()
        {
            var model = Application.Model as IModelApplicationCommandlineOptions;
            model.CommandlineOptions.SingeInstance.ShouldBe(true);
        }

        public void Dispose()
        {
            Application?.Dispose();
            Application = null;
        }
    }
}

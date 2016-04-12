using System;
using Para.ExpressApp.CommandLineLauncher.Win.Model;
using Shouldly;
using Xunit;

namespace Para.ExpressApp.CommandLineLauncher.Win
{
    public class ApplicationModelTests : IDisposable
    {
        TestApplication Application { get; set; }

        public ApplicationModelTests()
        {
            Application = new TestApplication();

            Application.Setup();
        }

        [Fact]
        public void ApplicationModelIsOptions()
        {
            var result = Application.Model is IModelApplicationCommandlineOptions;
            result.ShouldBe(true);
        }

        public void Dispose()
        {
            Application?.Dispose();
            Application = null;
        }
    }
}

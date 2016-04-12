using System;
using Shouldly;
using T360991.Module.Model;
using Xunit;

namespace T360991.Tests
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

using System;
using System.Collections.Generic;
using Para.ExpressApp.CommandLineLauncher.Win.Domain;
using Shouldly;
using Xunit;

namespace Para.ExpressApp.CommandLineLauncher.Win
{
    public class CommandLineParserTests : IDisposable
    {
        private TestApplication _application;

        public CommandLineParserTests()
        {
            _application = new TestApplication();

            _application.Modules.Add(new TestModule());

            _application.Setup();
        }

        [Theory]
        [MemberData(nameof(ParserTestData))]
        public void Parse(string[] arguments, string navigationItemId)
        {
            var parser = new CommandLineParser(_application.Model);

            var node = parser.Parse(arguments);

            node.View.Id.ShouldBe(navigationItemId);
        }

        public static IEnumerable<object[]> ParserTestData
        {
            get
            {
                yield return new object[] {new [] { "/Events" }, "Event_ListView"};
                yield return new object[] { new[] { "/People" }, "Person_ListView" };
            }
        }


        public void Dispose()
        {
            _application?.Dispose();
            _application = null;
        }
    }
}

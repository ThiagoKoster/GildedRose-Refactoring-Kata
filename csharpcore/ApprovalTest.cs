using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using FluentAssertions;

namespace csharpcore
{
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest
    {
        [Fact]
        public void ThirtyDays()
        {
            var fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();
            string text = System.IO.File.ReadAllText(@"ApprovalTest.ThirtyDays.received.txt");

            output.Should().Be(text);
            //Approvals.Verify(output);
        }
    }
}

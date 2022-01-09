using System;
using System.IO;
using System.Text;
using Xunit;

namespace UnitTest
{
    public class TestUtil
    {
        public static void Test(string inputString, string expectedOutputString, Action<string[]> targetFunc)
        {
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(inputString));

            using (var input = new StreamReader(stream))
            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                Console.SetIn(input);

                targetFunc(null);
                string outputString = output.ToString().Trim();
                Assert.Equal(expectedOutputString, outputString);
            }
        }
    }
}

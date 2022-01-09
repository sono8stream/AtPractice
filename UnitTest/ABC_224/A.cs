using System;
using System.IO;
using Xunit;

namespace UnitTest.ABC_224
{
    public class A
    {
        [Fact]
        public void Test1()
        {
            bool result = true;
            Assert.True(result, "result should be true");
            string inputString = "高橋AtCoder";
            string expectedOutputString = "er";
            TestUtil.Test(inputString, expectedOutputString, AtPractice.ABC_224.A.Method);
        }
    }
}

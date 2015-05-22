using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignMonitor;

namespace CampaignMonitor.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRequirement1()
        {
            string value = null;

            var result = value.IsNullOrEmpty();
            Assert.IsTrue(result);

            value = "";
            result = value.IsNullOrEmpty();
            Assert.IsTrue(result);

            value = "a";
            result = value.IsNullOrEmpty();
            Assert.IsFalse(result);

            value = "null";
            result = value.IsNullOrEmpty();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestRequirement2()
        {
            var result = Questions.PositiveDivisors(60);

            Assert.IsNotNull(result);

            result = Questions.PositiveDivisors(42);

            Assert.IsNotNull(result);

            result = Questions.PositiveDivisors(-60);

            Assert.IsNull(result);

            result = Questions.PositiveDivisors(0);

            Assert.IsNull(result);

            result = Questions.PositiveDivisors(int.MaxValue);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestRequirement3()
        {
            var a = Questions.AreaOfTriangle(3, 4, 5);

            Assert.IsNotNull(a);

            try
            {
                a = Questions.AreaOfTriangle(-100, 4, 5);
                Assert.Fail("no exception thrown");
            }
            catch (Exception ex)
            {
                Assert.AreSame(ex.Message, "InvalidTriangleException");
            }

            try
            {
                a = Questions.AreaOfTriangle(int.MaxValue, 4, 5);
                Assert.Fail("no exception thrown");
            }
            catch(Exception ex)
            {
                Assert.AreSame(ex.Message, "InvalidTriangleException");
            }

            try
            {
                a = Questions.AreaOfTriangle(3, 4, 1);
                Assert.Fail("no exception thrown");
            }
            catch(Exception ex)
            {
                Assert.AreSame(ex.Message, "InvalidTriangleException");
            }

        }
       
    }
}

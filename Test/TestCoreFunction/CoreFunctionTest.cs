using Core.CoreFunctions;
using NUnit.Framework;

namespace Test.TestCoreFunction
{
    [TestFixture]
    public class CoreFunctionTest
    {
        [TestCase(3, 1, 3, true)]
        [TestCase(0, 2, 4, false)]
        public void Check_Between_Function(int num, int lower, int upper, bool expectedValue)
        {
            var isValid = CoreFunction.Between(num, lower, upper);
            Assert.AreEqual(expectedValue, isValid);
        }

        [TestCase("3 3", true)]
        [TestCase("0 4", true)]
        [TestCase("0 0", false)]
        [TestCase("A 4", false)]
        [TestCase("55", false)]
        public void Check_Is_Plateau_Limit_Valid(string value, bool expectedValue)
        {
            var isValid = CoreFunction.IsPlateauLimitValid(value);
            Assert.AreEqual(expectedValue, isValid);
        }

        [TestCase("3 3 E", true)]
        [TestCase("0 4 N", true)]
        [TestCase("0 5 H", false)]
        [TestCase("A 4 W", false)]
        [TestCase("55 E", false)]
        public void Check_Is_Location_And_Direction_Valid(string value, bool expectedValue)
        {
            var isValid = CoreFunction.IsLocationAndDirectionValid(value);
            Assert.AreEqual(expectedValue, isValid);
        }
    }
}
using Business.Context;
using NUnit.Framework;

namespace Test.TestPlateau
{
    [TestFixture]
    public class PlateauTest
    {
        [TestCase(1, 1, true)]
        [TestCase(5, 3, true)]
        [TestCase(0, 0, false)]
        public void Check_Plateau_Size_Is_Valid(int limitX, int limitY, bool expectedValue)
        {
            var plateau = new Plateau(limitX, limitY);
            var isValid = plateau.CheckIsSizeValid();
            Assert.AreEqual(expectedValue, isValid);
        }
    }
}
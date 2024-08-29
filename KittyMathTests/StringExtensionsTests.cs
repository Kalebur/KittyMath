using KittyMath;

namespace KittyMathTests
{
    public class StringExtensionsTests
    {

        // Using the TestCase attribute, you set up the input and expected values
        // to be passed into the test method. If you run these tests, all of them
        // except the last one should pass. I'm sure you can figure out why it's
        // failing.
        [TestCase("zero", 0)]
        [TestCase("one", 1)]
        [TestCase("TwO", 2)]
        [TestCase("ThReE", 3)]
        [TestCase("FouR", 4)]
        [TestCase("fIVe", 5)]
        [TestCase("SIX", 6)]
        [TestCase("seVEn", 7)]
        [TestCase("EIGHT", 8)]
        [TestCase("niNE", 9)]
        [TestCase("oneTwo3fOuR.eIgHtSevEn", 1234.87)]
        [TestCase("nInE8FOur.sEVeNSevEN", 984.77)]
        [TestCase("SEVENFOURONENINE.EIGHTTWO", 7419.82)]
        [TestCase("oneoneoneoneonethree.twofour", 111113.24)]
        [TestCase("EigHtSevENonEONe.zeROtWO", 8711.02)]
        public void ConvertToNumber_ReturnsConvertedDecimalValueOfGivenString(string input, decimal expected)
        {
            // Tests are typically set up in an Arrange, Act, Assert order
            // There's nothing we need to Arrange in this test, so that step can
            // be left out

            // Act
            // For this test, all we're doing is converting the input string
            // to a decimal value and storing that value in result
            var result = input.ConvertToNumber();

            // Assert
            // This is where the actual comparison of the result of the Act stage
            // and our expected result takes place. In this test, we want to make
            // sure that the value returned from our ConvertToNumber() method
            // is equal to the expected value that we pass in.
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
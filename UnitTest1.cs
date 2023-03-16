using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTC
{
    [TestClass]
    public class UnitTest1
    {

        InvoiceGeneratot invoiceGenerator = null;
        [TestMethod]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Arrange
            invoiceGenerator=new InvoiceGeneratot(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;
            double expected = 25;

            //Act
            double fare=invoiceGenerator.CalculateFare(distance, time);

            //Assert

            Assert.AreEqual(expected, fare);
        }
    }
}
namespace CabInvoiceGenerator
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to cab invoice generator");
            InvoiceGeneratot invoice = new InvoiceGeneratot(RideType.NORMAL);

            double fare = invoice.CalculateFare(2.0, 5);
            Console.WriteLine(fare);
        }
    }

}
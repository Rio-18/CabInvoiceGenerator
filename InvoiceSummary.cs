using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        private int numberofRides;
        private double totalFare;
        private double averageFare;

        public InvoiceSummary(int numberofRides,double totalFare)
        {
            this.numberofRides= numberofRides;
            this.totalFare= totalFare;
            this.averageFare=this.totalFare/this.numberofRides;
        }
    }
}

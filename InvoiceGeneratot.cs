using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGeneratot
    {
        RideType rideType;
        private RideRepo rideRepo;

        private double MINUMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;

        public InvoiceGeneratot(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepo = new RideRepo();
            try
            {
                if(rideType.Equals(RideType.PREMIUM))
                {
                    this.MINUMUM_COST_PER_KM= 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE= 20;
                }
                else if(rideType.Equals(RideType.NORMAL))
                {
                    this.MINUMUM_COST_PER_KM= 10;
                    this.COST_PER_TIME  = 1;
                    this.MINIMUM_FARE= 5;
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride");
            }

        }
        public double CalculateFare(double distance,int time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINUMUM_COST_PER_KM + COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid ride");
                }
                if(distance<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if(time<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid time");
                }
            }
            return Math.Max(totalFare, distance);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE,"Invalid Ride");
                }
            }
            return new InvoiceSummary(rides.Length,totalFare);
        }
            
    }
}

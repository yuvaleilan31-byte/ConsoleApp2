using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class DeliveryDrone
    {
        public string id { get; }
        public double maxWeightCapacityKg { get; }
        public int batteryPercentage;
        public double currentAltitudeMeters { get; set; }

        public string status;

        public int BatteryPercentage
        {
            get { return this.batteryPercentage; }
            set
            {
                if (value >= 0 && value <= 100) { this.batteryPercentage = value; }
                DeliveryResults result = new DeliveryResults(false, this.id, "you put an unallowed number in the battery");
            }
        }

        public string Status
        {
            get { return this.Status; }
            set
            {
                if (value == "ReturningHome" || value == "InFlight" || value == "Grounded")
                {
                    this.status = value;
                }
                else
                {
                    DeliveryResults result = new DeliveryResults(false, this.id, "you put an unallowed status (not \"Grounded\", \"InFlight\" or \"ReturningHome\" )");

                }
            }
        }

        public DeliveryDrone(string id, double maxWeightCapacityKg)
        {
            this.status = "Grounded";
            this.currentAltitudeMeters = 0;
            this.batteryPercentage = 100;
            if (maxWeightCapacityKg > 0)
                this.maxWeightCapacityKg = maxWeightCapacityKg;
            else
            {
                throw new ArgumentOutOfRangeException("The high must be more than 0");
            }
            if (id == null || id == "")
                this.id = id;
            else
            {
                throw new ArgumentNullException("The id can't be null");
            }
        }

        public DeliveryResults TakeOff()
        {
            if (this.batteryPercentage < 30)
            {
                DeliveryResults fail = new DeliveryResults(false, this.id, "low battery");
                return fail;
            }
            if (this.status != "Grounded")
                throw new InvalidOperationException("status isn't Graunded");
            this.status = "InFlight";
            this.currentAltitudeMeters = 50;
             
            return new DeliveryResults(true, this.id, "success");
        }

        public DeliveryResults AssignDelivery(double packageWeight, int distanceKm)
        {
            if (packageWeight > this.maxWeightCapacityKg)
                return new DeliveryResults(false, this.id, "too much weight");
            if (distanceKm > this.batteryPercentage)
                return new DeliveryResults(false, this.id, "dosen't have enough battery");
            if (this.status != "InFlight")
                throw new InvalidOperationException("Not in flight");
            this.batteryPercentage -= distanceKm;
            this.status = "ReturningHome";
            return new DeliveryResults(true, this.id, "success");
        }
        public void land()
        {
            if (this.status != "ReturningHome")
                throw new InvalidOperationException("Not in 'returning home' mode");
            this.currentAltitudeMeters = 0;
            this.status = "Grounded";

        }


    }
}

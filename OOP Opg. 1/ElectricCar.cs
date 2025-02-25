namespace OOP_Opg_1
{
    internal class ElectricCar : Car
    {
        private double battery = 100;

        public void InitElectricCar(string model, string brand, int year, int speed, double battery)
        {
            InitVehicle(model, brand, year, speed);
            this.battery = battery;
        }

        public override void Refuel(double electricity)
        {
            this.battery = electricity;
            Console.WriteLine($"Refueling the vehicle the battery was {this.battery} kWh, and is now {electricity} kWh");
        }

        public override void Drive(int speed)
        {
            if (battery > 0)
            {
                base.Drive(speed);
                battery -= 0.5;
                Console.WriteLine($"Driving at {speed} km/h, the battery is now {this.battery} kWh");
            }
            else
            {
                Console.WriteLine("Not enough battery");
            }
        }
        

    }
}

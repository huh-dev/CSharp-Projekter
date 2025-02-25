namespace OOP_Opg_1
{
    internal class Car
    {

        private string model;
        private string brand;
        private int year;
        private int speed;
        private double fuel = 100;

        public void InitVehicle(string model, string brand, int year, int speed)
        {
            this.model = model;
            this.brand = brand;
            this.year = year;
            this.speed = speed;
        }
        public virtual void Drive(int speed)
        {

            if (fuel > 0)
            {
                this.speed = speed;
                fuel -= 0.5;
                Console.WriteLine($"Driving at {speed} km/h, the fuel is now {fuel} liters");
            }
            else
            {
                Console.WriteLine("Not enough fuel");
            }
        }

        public virtual void Stop()
        {
            this.speed = 0;
            Console.WriteLine("Stopping the vehicle and setting speed to 0");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Model: {model}, Brand: {brand}, Year: {year}, Speed: {speed}");
        }

        public virtual void Refuel(double fuel)
        {
            Console.WriteLine($"The fuel was {this.fuel} liters, and is now {fuel} liters");
            this.fuel = fuel;   
        }

    }
}

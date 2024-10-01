

namespace Practice1
{
    class Scooter: Vehicle
    {
        private static string typeOfVehicle = "Scooter";

        public Scooter() : base(typeOfVehicle) 
        { 
        }


        public void StartRide()
        {
            Console.WriteLine(WriteMessage("The scooter ride has started"));
        }

        public void StopRide()
        {
            Console.WriteLine(WriteMessage("The scooter ride has stopped"));
        }
    }
}

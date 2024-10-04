

namespace Practice1
{
    class VehicleWithPlate: Vehicle
    {
        private string plate;
        private string typeOfVehicle;

        public VehicleWithPlate(string typeOfVehicle, string plate) : base(typeOfVehicle)
        {
            this.plate = plate;
        }

        public string GetPlate()
        {
            return plate;
        }

        public override string ToString()
        {
            return $"{GetTypeOfVehicle()} with plate {GetPlate()}";
        }

    }
}

namespace Practice1
{
    class SpeedRadar : IMessageWritter
    {
        private string plate;
        private float speed;
        private float legalSpeed = 50.0f;
        public List<float> SpeedHistory { get; private set; }

        public SpeedRadar()
        {
            plate = "";
            speed = 0f;
            SpeedHistory = new List<float>();
        }

        public void TriggerRadar(VehicleWithPlate vehiclePlate)
        {
            plate = vehiclePlate.GetPlate();
            speed = vehiclePlate.GetSpeed();
            SpeedHistory.Add(speed);
        }
        
        public string GetLastReading()
        {
            if (speed > legalSpeed)
            {
                return WriteMessage("Catched above legal speed.");
            }
            else
            {
                return WriteMessage("Driving legally.");
            }
        }

        public bool IsSpeeding(Vehicle vehicle)
        {
            return vehicle.GetSpeed() > legalSpeed;
        }

        public virtual string WriteMessage(string radarReading)
        { 
            return $"Vehicle with plate {plate} at {speed.ToString()} km/h. {radarReading}";
        }
    }
}
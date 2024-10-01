namespace Practice1
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car";
        public bool IsPatrolling { get; private set; }  // Ahora es una propiedad pública con setter privado
        public bool IsPursuing { get; private set; }    // Propiedad pública con setter privado
         private SpeedRadar? speedRadar; // Puede tener, O NO, un radar

        public PoliceCar(string plate, SpeedRadar? speedradar = null) : base(typeOfVehicle, plate)
        {
            IsPatrolling = false;
            IsPursuing = false;
            speedRadar = speedradar;
        }

        public void SetRadar(SpeedRadar speedRadar)
        {
            this.speedRadar = speedRadar;
        }
        public void UseRadar(Vehicle vehicle)
        {
            if (IsPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);

                    string meassurement = speedRadar.GetLastReading();
                    Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
                }
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
        }

        public void StartPatrolling()
        {
            if (!IsPatrolling)
            {
                IsPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (IsPatrolling)
            {
                IsPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void RecibeAlert(string infractorPlate)
        {
            if (IsPatrolling)
            {
                StartPursuing(infractorPlate);
            }
        }

        public void StartPursuing(string infractorPlate)
        {
            IsPursuing = true;
            Console.WriteLine($"Coche de policía con matrícula {GetPlate()} está persiguiendo a {infractorPlate}");
        }

        public void PrintRadarHistory()
        {
            if (speedRadar != null)
            {

                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine($"El coche con matrícula {GetPlate()} no tiene radar incorporado");
            }
        }
    }
}

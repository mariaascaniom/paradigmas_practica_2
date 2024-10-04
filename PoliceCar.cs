namespace Practice1
{
    class PoliceCar : VehicleWithPlate
    {

        private const string typeOfVehicle = "Police Car";
        public bool IsPatrolling { get; private set; }  
        public bool IsPursuing { get; private set; }    
        private SpeedRadar? speedRadar;
        private PoliceStation policeStation;

        public PoliceCar(string plate, PoliceStation policeStation, SpeedRadar? speedradar = null) : base(typeOfVehicle, plate)
        {
            IsPatrolling = false;
            IsPursuing = false;
            speedRadar = speedradar;
            this.policeStation = policeStation;
        }

        public void SetRadar(SpeedRadar speedRadar)
        {
            this.speedRadar = speedRadar;
        }
        public void UseRadar(VehicleWithPlate vehicle)
        {
            if (IsPatrolling)
            {
                if (speedRadar != null)
                {
                    speedRadar.TriggerRadar(vehicle);


                    if (speedRadar.IsSpeeding(vehicle))
                    {
                        Console.WriteLine(WriteMessage("Detecta velocidad ilegal"));
                        policeStation.NotifyPlate(vehicle.GetPlate());
                    }
                    else
                    {
                        Console.WriteLine(WriteMessage("No detecta infracciones."));
                    }
                }
                else
                {
                    Console.WriteLine(WriteMessage("No se puede usar radar, este coche no lo tiene"));
                }

            }

            else
            {
                Console.WriteLine(WriteMessage($"Police car is not patrolling"));
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

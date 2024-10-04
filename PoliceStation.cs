

namespace Practice1
{
    class PoliceStation
    {
        private List<PoliceCar> policeCars;
        private List<Taxi> registeredTaxis;
        private bool alert;

        public PoliceStation(List<Taxi> registeredTaxis)
        {
            this.policeCars = new List<PoliceCar>();
            this.registeredTaxis = registeredTaxis;
        }

        public void RegisterCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
        }

        public void RegisterTaxiLicense(Taxi taxi)
        {
            registeredTaxis.Add(taxi);
            Console.WriteLine($"Licencia de taxi {taxi.GetPlate()} registrada en la comisaría.");
        }

        public void RemoveTaxiLicense(string plate)
        {
            Taxi taxiToRemove = registeredTaxis.Find(t => t.GetPlate() == plate);
            if (taxiToRemove != null)
            {
                registeredTaxis.Remove(taxiToRemove);
                Console.WriteLine($"Licencia del taxi con matrícula {plate} ha sido retirada.");
            }
            else
            {
                Console.WriteLine($"Taxi con matrícula {plate} no encontrado.");
            }
        }
        public void NotifyPlate(string infractorPlate)
        {
            alert = true;
            Console.WriteLine("Alerta recibida en comisaría: Alertar de la persecución");
            foreach(var car in policeCars)
            {
                if (car.IsPatrolling)
                {
                    car.RecibeAlert(infractorPlate);
                }
            }

        }
    }

}

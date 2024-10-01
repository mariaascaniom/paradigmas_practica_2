

namespace Practice1
{
    class PoliceStation
    {
        private List<PoliceCar> policeCars;
        private bool alert;

        public PoliceStation()
        {
            this.policeCars = new List<PoliceCar>();
        }

        public void RegisterCar(PoliceCar policeCar)
        {
            policeCars.Add(policeCar);
        }

        public void NotifyPlate(string infractorPlate)
        {
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

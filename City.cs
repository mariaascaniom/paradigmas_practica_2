
namespace Practice1
{
    class City
    {
        private List<Taxi> TaxiList;
        private PoliceStation policeStation;

        public City()
        { 
            TaxiList = new List<Taxi>();
            policeStation = new PoliceStation();
            Console.WriteLine("Ciudad creada");
        }

        public void RegisterTaxi(Taxi taxi)
        {
            TaxiList.Add(taxi);
            Console.WriteLine(taxi.WriteMessage("Registrado en la ciudad"));
        }

        public List<Taxi> GetTaxiList()
        {
            return TaxiList;
        }

    }
}

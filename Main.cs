
namespace Practice1
    {
        internal class Program
        {
            static void Main()
            {
                // 1. Creación de la ciudad, que incluye una comisaría
                City city = new City();
                PoliceStation policeStation = city.GetPoliceStation();

                // 2. Registro de varios taxis en la ciudad
            
                Taxi taxi1 = new Taxi("0001 AAA");
                Taxi taxi2 = new Taxi("0002 BBB");
                Taxi taxi3 = new Taxi("0003 CCC");

                city.RegisterTaxi(taxi1);
                city.RegisterTaxi(taxi2);
                city.RegisterTaxi(taxi3);

                // 3. Registro de varios coches de policía (algunos con radar y otros sin radar)
                SpeedRadar radar = new SpeedRadar();
                PoliceCar policeCar1 = new PoliceCar("0001 CNP", policeStation, radar); 
                PoliceCar policeCar2 = new PoliceCar("0002 CNP", policeStation, null);   
                PoliceCar policeCar3 = new PoliceCar("0003 CNP", policeStation, radar);

                policeStation.RegisterCar(policeCar1);
                policeStation.RegisterCar(policeCar2);
                policeStation.RegisterCar(policeCar3);

                Console.WriteLine(policeCar1.WriteMessage("Registrado en la ciudad con radar."));
                Console.WriteLine(policeCar2.WriteMessage("Registrado en la ciudad sin radar."));
                Console.WriteLine(policeCar3.WriteMessage("Registrado en la ciudad con radar."));

                // 4. Intento de utilizar el radar en un coche de policía que no tiene radar
                policeCar2.StartPatrolling();
                policeCar2.UseRadar(taxi1); 


                // 5. Alerta a la comisaría para perseguir un vehículo con cierta matrícula
                // 6. Aviso de que los demás policías comienzan a perseguir el vehículo
                policeCar1.StartPatrolling();
                taxi1.StartRide();
                policeCar1.UseRadar(taxi1);

                //// 7. Quitar la licencia a uno de los taxis que haya sobrepasado la velocidad legal
                policeStation.RemoveTaxiLicense(taxi1.GetPlate());


                policeCar1.PrintRadarHistory();
                policeCar3.PrintRadarHistory();
            }
        }
    }





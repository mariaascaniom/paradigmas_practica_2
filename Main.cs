
namespace Practice1
    {
        internal class Program
        {
            static void Main()
            {
                // 1. Creación de la ciudad, que incluye una comisaría
                City city = new City();

                // 2. Registro de varios taxis en la ciudad
                Taxi taxi1 = new Taxi("0001 AAA");
                Taxi taxi2 = new Taxi("0002 BBB");
                Taxi taxi3 = new Taxi("0003 CCC");

                city.RegisterTaxi(taxi1);
                city.RegisterTaxi(taxi2);
                city.RegisterTaxi(taxi3);

                // 3. Registro de varios coches de policía (algunos con radar y otros sin radar)
                SpeedRadar radar1 = new SpeedRadar();
                PoliceCar policeCar1 = new PoliceCar("0001 CNP", radar1); 
                PoliceCar policeCar2 = new PoliceCar("0002 CNP", null);   
                PoliceCar policeCar3 = new PoliceCar("0003 CNP", radar1); 

                Console.WriteLine(policeCar1.WriteMessage("Registrado en la ciudad con radar."));
                Console.WriteLine(policeCar2.WriteMessage("Registrado en la ciudad sin radar."));
                Console.WriteLine(policeCar3.WriteMessage("Registrado en la ciudad con radar."));

                // 4. Intento de utilizar el radar en un coche de policía que no tiene radar
                policeCar2.StartPatrolling();
                policeCar2.UseRadar(taxi1); // No tiene radar, debe imprimir un mensaje adecuado

                // 5. Alerta a la comisaría para perseguir un vehículo con cierta matrícula
                policeCar1.StartPatrolling();
                taxi1.SetSpeed(100); // Taxi 1 sobrepasa la velocidad legal
                policeCar1.UseRadar(taxi1); // Detecta el exceso de velocidad y lanza la alerta

                // 6. Aviso de que los demás policías comienzan a perseguir el vehículo
                policeCar3.StartPatrolling();
                Console.WriteLine("Aviso: Todos los policías empiezan a perseguir al vehículo con matrícula " + taxi1.GetPlate() + ".");
                policeCar3.UseRadar(taxi1);

                //// 7. Quitar la licencia a uno de los taxis que haya sobrepasado la velocidad legal
                //if (taxi1.GetSpeed() > SpeedRadar.LegalSpeed)
                //{
                //    taxi1.RemoveLicense();
                //    Console.WriteLine(taxi1.WriteMessage("Licencia retirada por exceso de velocidad."));
                //}

                //// 8. Imprimir historial de radar de los coches de policía
                //policeCar1.PrintRadarHistory();
                //policeCar3.PrintRadarHistory();
            }
        }
    }





using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            var recursionExample = new RecursionExample();

            var a = recursionExample.SumLength(1, 200);
 
            Console.ReadKey();
            IAirplaneFacade airplaneFacade = new AirplaneFacade();
            airplaneFacade.TakeOff();
        }
    }

    public interface IAirplaneFacade
    {
        void TakeOff();
        void Land();
    }

    public class AirplaneFacade : IAirplaneFacade
    {
        public void TakeOff()
        {
            var airplane = new Airplane();
            var securityStaff = new SecurityStaff();
            var tower = new Tower();
            var passengers = new Passenger[5];
            passengers[0] = new Passenger();
            passengers[1] = new Passenger();
            passengers[2] = new Passenger();
            passengers[3] = new Passenger();
            passengers[4] = new Passenger();

            //1. Säkerhetskontroll av planet
            securityStaff.Checkout(airplane);
            airplane.Board(passengers);
            Task.Run(() => airplane.RequestTakeOff(tower));
        }

        public void Land()
        {
            throw new NotImplementedException();
        }
    }

    public class Airplane
    {
        private List<Engine> Engines { get; set; } = new List<Engine> {new Engine(), new Engine()};
        private LandingGear LandingGear { get; set; } = new LandingGear();

        public void Board(IEnumerable<Passenger> passengers)
        {

        }

        public void Taxi()
        {

        }

        public async Task RequestTakeOff(Tower tower)
        {
            await tower.RequestTakeOff(response =>
            {
                //Handle response from tower
            });
        }

        public void Warmup(string position = null)
        {
            if (!string.IsNullOrWhiteSpace(position))
            {
                var engine = Engines.FirstOrDefault(e => e.Position.Equals(position, StringComparison.OrdinalIgnoreCase));
                engine?.Warmup();
                return;
            }

            foreach (var engine in Engines)
            {
                engine.Warmup();

            }
        }

        public void StartEngine()
        {
            foreach (var engine in Engines)
            {
                engine.Start();
            }
        }

        public void Accelerate()
        {
            foreach (var engine in Engines)
            {
                engine.IncreaseEffect();
            }
        }
    }

    public class SecurityStaff
    {
        public bool Checkout(Airplane airplane)
        {
            return false;
        }
    }

    public class Passenger
    {

    }

    public class Tower
    {
        public async Task RequestTakeOff(Action<bool> callback)
        {

        }
    }

    public class Engine
    {
        public string Position { get; set; }

        public void Warmup()
        {

        }

        public void Start()
        {

        }

        public void IncreaseEffect()
        {

        }
    }

    public class LandingGear
    {

    }
}

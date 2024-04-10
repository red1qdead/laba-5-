// Інтерфейс 
public interface IShip
{
    int CargoCapacity { get; }
    int GetNumberOfCannons();
    int GetMaxPassengers();
}

// абстрактний клас 
public abstract class Ship : IShip
{
    public int CargoCapacity { get; protected set; }

    public Ship(int cargoCapacity)
    {
        CargoCapacity = cargoCapacity;
    }

    public virtual int GetNumberOfCannons() => 0;
    public abstract int GetMaxPassengers();
}

// Воєнний корабель
public class Warship : Ship
{
    public Warship(int cargoCapacity) : base(cargoCapacity) { }

    public override int GetNumberOfCannons() => 50;
    public override int GetMaxPassengers() => 200;
}

// Авіаносець
public class AircraftCarrier : Warship // тип
{
    public AircraftCarrier(int cargoCapacity) : base(cargoCapacity) { }

    public override int GetNumberOfCannons() => 20;
    public override int GetMaxPassengers() => 5000;
}

// Пасажирський корабель
public class PassengerShip : Ship
{
    public PassengerShip(int cargoCapacity, int maxPassengers) : base(cargoCapacity)
    {
        MaxPassengers = maxPassengers;
    }

    public int MaxPassengers { get; private set; }

    public override int GetMaxPassengers() => MaxPassengers;
}

// Фрегат
public class Frigate : Warship
{
    public Frigate(int cargoCapacity) : base(cargoCapacity) { }

    public override int GetNumberOfCannons() => 30;
    public override int GetMaxPassengers() => 100;
}

// Паром
public class Ferry : PassengerShip
{
    public Ferry(int cargoCapacity, int maxPassengers) : base(cargoCapacity, maxPassengers) { }
}

// Круїзний лайнер
public class CruiseLiner : PassengerShip
{
    public CruiseLiner(int cargoCapacity, int maxPassengers) : base(cargoCapacity, maxPassengers) { }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Ship[] fleet = new Ship[]
        {
            new Warship(5000),
            new AircraftCarrier(10000),
            new PassengerShip(3000, 500),
            new Frigate(4000),
            new Ferry(2000, 600),
            new CruiseLiner(8000, 2500)
        };

        foreach (var ship in fleet)
        {
            Console.WriteLine($"{ship.GetType().Name} - Грузопідйомність: {ship.CargoCapacity}, " +
                              $"Гармати: {ship.GetNumberOfCannons()}, " +
                              $"Макс. пасажири: {ship.GetMaxPassengers()}");
        }
    }
}
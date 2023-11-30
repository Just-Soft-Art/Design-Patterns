interface IMovable
{
    void Move();
}

class PetrolMove : IMovable
{
    public void Move() =>
        Console.WriteLine("Move on petrol");
}

class ElectricMove : IMovable
{
    public void Move() =>
        Console.WriteLine("Move on electricity");
}

class Car
{
    public Car(IMovable mov)
    {
        Movable = mov;
    }
    public IMovable Movable { private get; set; }
    public void Move()
    {
        Movable.Move();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Car auto = new Car(new PetrolMove());
        auto.Move();
        auto.Movable = new ElectricMove();
        auto.Move();
        auto.Movable = new PetrolMove();
        auto.Move();

        Console.ReadKey();
    }
}

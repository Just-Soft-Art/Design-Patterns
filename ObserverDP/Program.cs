interface IObserver
{
    void Update();
}

interface IObservable
{
    void AddObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}

class ConcreteObservable : IObservable
{
    private List<IObserver> observers;
    public ConcreteObservable()
    {
        observers = new List<IObserver>();
    }
    public void AddObserver(IObserver o)
    {
        observers.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observers.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
            observer.Update();
    }
}

class ConcreteObserver : IObserver
{
    public void Update()
    {
        Console.WriteLine("Updated!");
    }
}

namespace ObserverDP
{
    class ObserverDP
    {
        static void Main(string[] args)
        {
            ConcreteObservable superStart = new ConcreteObservable();
            ConcreteObserver sub1 = new ConcreteObserver();
            ConcreteObserver sub2 = new ConcreteObserver();
            ConcreteObserver sub3 = new ConcreteObserver();
            ConcreteObserver sub4 = new ConcreteObserver();

            superStart.AddObserver(sub1);
            superStart.AddObserver(sub2);
            superStart.AddObserver(sub3);
            superStart.AddObserver(sub4);

            superStart.NotifyObservers();
        }
    }
}
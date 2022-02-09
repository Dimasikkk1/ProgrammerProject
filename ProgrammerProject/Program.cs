var programmer = new SomeProgrammer(new CoffeeCup(500));

programmer.Programming();

Console.ReadKey(true);

public abstract class Cup
{
    protected readonly int volume;

    public virtual int CurrentVolume { get; protected set; }
    public virtual bool IsEmpty => CurrentVolume <= 0;

    public Cup(int volume)
    {
        this.volume = volume;
    }

    public virtual void Drink(int volume)
    {
        CurrentVolume = (CurrentVolume -= volume) < 0 ? 0 : CurrentVolume;
    }

    public virtual void Fill()
    {
        CurrentVolume = volume;
    }
}

internal class CoffeeCup : Cup
{
    public CoffeeCup(int volume) : base(volume)
    {
    }
}

public abstract class Programmer
{
    protected static readonly Random random = new();

    protected readonly Cup cup;

    public Programmer(Cup cup)
    {
        this.cup = cup;
    }

    public virtual void Programming()
    {
        while (true)
        {
            if (cup.IsEmpty)
                cup.Fill();

            DoSomething();

            cup.Drink(random.Next(50, 101));
        }
    }

    protected virtual void DoSomething()
    {
        Thread.Sleep(random.Next(1000, 5001));
    }
}

internal class SomeProgrammer : Programmer
{
    public SomeProgrammer(Cup cup) : base(cup)
    {
    }
}

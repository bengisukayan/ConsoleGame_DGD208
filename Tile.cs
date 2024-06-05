using static BigBadCat.Program;

public interface ITile //Tile interface for Factory design pattern
{
    char Symbol { get; } //expression-bodied property
    void SpecialMessage(); //method to implement
}

public class Cat : ITile //implementing the ITile interface
{
    public char Symbol => 'C';  //implement variables

    public void SpecialMessage() //implement SpecialMessage() function
    {
        Console.WriteLine("You hear a dangerous purring...");
    }
}
public class Vomit : ITile
{
    public char Symbol => 'V';

    public void SpecialMessage()
    {
        Console.WriteLine("You smell a very asidic smell nearby...");
    }
}
public class Exit : ITile
{
    public char Symbol => 'E';
    public void SpecialMessage() {}

}

public class TileFactory //tile creation factory
{
    public ITile CreateTile(string type)
    {
        switch(type) //check which object we are creating
        {
            case "cat":
                return new Cat();
            case "vomit":
                return new Vomit();
            case "exit":
                return new Exit();
            default:
                throw new ArgumentException("Invalid tile type"); //throw exception in case of invalid tile name. Actually can command this line, as we don't creates tiles by input
        };
    }
}
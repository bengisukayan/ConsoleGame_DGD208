using static BigBadCat.Program;

public class Tile //Tile object I used as an interface, not exactly but kind of, as I never used Tile as it's own.
{
    public char symbol = '0';
    public void SpecialMessage()
    {
        Console.WriteLine("Nearby tile message");
    }
}

public class Cat : Tile //inheriting from the Tile class.
{
    public char symbol = 'C';  //overriding variables

    public void SpecialMessage() //overriding SpecialMessage() function
    {
        Console.WriteLine("You hear a dangerous purring...");
    }
}
public class Vomit : Tile
{
    public char symbol = 'V';

    public void SpecialMessage()
    {
        Console.WriteLine("You smell a very asidic smell nearby...");
    }
}
public class Exit : Tile
{
    public char symbol = 'E';

}
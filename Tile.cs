using static BigBadCat.Program;

public class Tile //Tile object I used as an interface, not exactly but kind of, as I never used Tile as it's own.
{
    public char symbol = '0';
    public void specialMessage()
    {
        Console.WriteLine("Nearby tile message");
    }
    public void GameOver()
    {
        Game.gameOn = false;
    }
}

public class Cat : Tile //inheriting from the Tile class.
{
    public char symbol = 'C';  //overriding variables

    public void SpecialMessage() //overriding SpecialMessage() function
    {
        Console.WriteLine("You hear a dangerous purring...");
    }
    public void GameOver() //overriding GameOver() function
    {
        Console.Clear(); //clearing terminal
        Console.WriteLine("Game over! You woke the Big Bad Cat!");
        Thread.Sleep(3000); //waiting for 3 seconds
        Game.gameOn = false; //stopping the game loop
    }
}
public class Vomit : Tile
{
    public char symbol = 'V';

    public void SpecialMessage()
    {
        Console.WriteLine("You smeel a very asidic smell nearby...");
    }
    public void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Game over! You stepped on a very hazardous vomit!");
        Thread.Sleep(3000);
        Game.gameOn = false;
    }
}
public class Exit : Tile
{
    public char symbol = 'E';

    public void GameOver()
    {
        Console.Clear(); 
        Console.WriteLine("Good job! You are rich now, you've found the Golden Claw!");
        Console.WriteLine($"Your Score is: {score}");
        Thread.Sleep(3000);
        Game.gameOn = false;
    }
}
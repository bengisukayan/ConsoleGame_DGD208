using static BigBadCat.Program;

public class Map
{
    public char[,] map = new char[4, 4]; //2 dimensional array as map
    public int coord_x; //player coordinates
    public int coord_y;

    public Map()
    {
        Random random = new Random();
        int num = random.Next(0, 4); //randomize a number to pick a random map

        for (int i = 0; i < 4; i++) //initialize the map, picking 2 dimensional map from static array, check the Program.cs
        {
            for (int j = 0; j < 4; j++)
                map[i, j] = maps[num, i, j];
        }

        coord_x = findPlayer() % 4;
        coord_y = findPlayer() / 4;
    }
    private int findPlayer() 
    {
        for (int i = 0; i < 4; i++) //columns
        {
            for (int j = 0; j < 4; j++) //rows
            {
                if (map[i, j] == 'P')
                    return (i*4 + j);
            }
        }
        return 0;
    }

    public void move(char c) //change player's coordinates
    {
        switch (c)
        {
            case 'w':
                if (coord_y != 0) //check borders
                    coord_y--; //move up
                break;
            case 'a':
                if (coord_x != 0) //check borders
                    coord_x--; //move left
                break;
            case 's':
                if (coord_y != 3) //check borders
                    coord_y++; //move right
                break;
            case 'd':
                if (coord_x != 3) //check borders
                    coord_x++; //move down
                break;
        }
        this.renderMap();
    }
    public void renderMap() //Printing the map for better UI
    {
        Console.Clear(); //flush terminal

        for (int i = 0; i < 4; i++) //columns
        {
            for (int j = 0; j < 4; j++) //rows
            {
                if (i == coord_y && j == coord_x)
                    Console.Write('X'); //mark the player as X
                else
                    Console.Write('O');
            }
            Console.WriteLine();
        }

        checkSurroundings();
    }

    private void checkSurroundings()
    {
        TileFactory factory = new TileFactory(); //create tile factory
        ITile cat = factory.CreateTile("cat");
        ITile vomit = factory.CreateTile("vomit");
        ITile exit = factory.CreateTile("exit");
        char symbol = map[coord_y, coord_x];

        if (symbol == cat.Symbol) //checking where player stands and if the game is over
        {
            Game.GameOver('C');
            return; //return so special messages won't show after finishing
        } 
        else if (symbol == vomit.Symbol)
        {
            Game.GameOver('V');
            return;
        }
        else if (symbol == exit.Symbol)
        {
            Game.GameOver('E');
            return;
        }

        if (coord_y != 0 && map[coord_y - 1, coord_x] == cat.Symbol) //checking upper tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_y != 0 && map[coord_y - 1, coord_x] == vomit.Symbol)
            vomit.SpecialMessage();

        if (coord_y != 3 && map[coord_y + 1, coord_x] == cat.Symbol) //checking down tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_y != 3 && map[coord_y + 1, coord_x] == vomit.Symbol)
            vomit.SpecialMessage();

        if (coord_x != 0 && map[coord_y, coord_x - 1] == cat.Symbol) //checking left tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_x != 0 && map[coord_y, coord_x - 1] == vomit.Symbol)
            vomit.SpecialMessage();

        if (coord_x != 3 && map[coord_y, coord_x + 1] == cat.Symbol) //checking right tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_x != 3 && map[coord_y, coord_x + 1] == vomit.Symbol)
            vomit.SpecialMessage();
    }
}
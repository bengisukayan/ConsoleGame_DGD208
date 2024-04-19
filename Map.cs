﻿using static BigBadCat.Program;

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
        Cat cat = new Cat();
        Vomit vomit = new Vomit();
        Exit exit = new Exit();
        char symbol = map[coord_y, coord_x];

        if (symbol == cat.symbol) //checking where player stands and if the game is over
            cat.GameOver();
        else if (symbol == vomit.symbol)
            vomit.GameOver();
        else if (symbol == exit.symbol) 
            exit.GameOver();

        if (coord_y != 0 && map[coord_y - 1, coord_x] == cat.symbol) //checking upper tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_y != 0 && map[coord_y - 1, coord_x] == vomit.symbol)
            vomit.SpecialMessage();

        if (coord_y != 3 && map[coord_y + 1, coord_x] == cat.symbol) //checking down tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_y != 3 && map[coord_y + 1, coord_x] == vomit.symbol)
            vomit.SpecialMessage();

        if (coord_x != 0 && map[coord_y, coord_x - 1] == cat.symbol) //checking left tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_x != 0 && map[coord_y, coord_x - 1] == vomit.symbol)
            vomit.SpecialMessage();

        if (coord_x != 3 && map[coord_y, coord_x + 1] == cat.symbol) //checking right tile, if it is not a border
            cat.SpecialMessage();
        else if (coord_x != 3 && map[coord_y, coord_x + 1] == vomit.symbol)
            vomit.SpecialMessage();
    }

    /* maybe could use map generation, but needs error checks
    private void generateMap()
    {
        Random random = new Random();
        int num = random.Next(1, 17);
        map[num / 4, (num % 4) - 1] = 'P';

        num = random.Next(1, 17);
        while (map[num / 4, (num % 4) - 1] != 0)
            num = random.Next(1, 17);
        map[num / 4, (num % 4) - 1] = 'C';

        for (int j = 3; j > 0; j--)
        {
            num = random.Next(1, 17);
            while (map[num / 4, (num % 4) - 1] != 0)
                num = random.Next(1, 17);
            map[num / 4, (num % 4) - 1] = 'V';
        }

        num = random.Next(1, 17);
        while (map[num / 4, (num % 4) - 1] != 0)
            num = random.Next(1, 17);
        map[num / 4, (num % 4) - 1] = 'E';
    }
    */
}
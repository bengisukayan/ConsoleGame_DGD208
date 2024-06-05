using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScoreManager //ScoreManager class using Singleton design pattern.
{
    private static ScoreManager instance; //static instance

    private const string ScoreFilePath = "scorekeep.txt"; //scorekeep file path (check in project folder: ..\bin\Debug\net8.0)

    private ScoreManager() {} //private constructor for preventing uncontrolled object creations

    public static ScoreManager GetInstance() //getter of instance
    {
        if (instance == null) //if no instance create one
            instance = new ScoreManager();
        return instance; //if exist return it
    }

    public void SaveScore(string playerName, int score) //method for saving score and names
    {
        using (StreamWriter writer = new StreamWriter(ScoreFilePath, true)) //using StreamWriter writer and appending into scorekeep file
        {
            writer.WriteLine($"{playerName}:{score}");
        }
    }

    public (string playerName, int score) GetHighScore() //method for finding highest score
    {
        if (!File.Exists(ScoreFilePath)) //check if file exist for error check
            return ("", 0);

        var scores = new List<(string playerName, int score)>(); //use Generic List<T> to keep names and scores as tuple
        using (StreamReader reader = new StreamReader(ScoreFilePath)) //using StreamReader reader to read
        {
            string buffer; //buffer for reading
            while ((buffer = reader.ReadLine()) != null) //read lines one by one
            {
                var parts = buffer.Split(':'); //split upon char ':'
                int score = int.Parse(parts[1]); //convert string score value to integer
                scores.Add((parts[0], score)); //save as tuple, name and score
            }
        }
        
        return scores.OrderByDescending(s => s.score).FirstOrDefault(); //LINQ usage: order by decreasing scores and fetch first/highest value
    }
}

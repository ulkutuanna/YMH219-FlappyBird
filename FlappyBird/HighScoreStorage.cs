using System;
namespace FlappyBird;

public class HighScoreStorage
{
    
    private readonly string filePath =
        Path.Combine(AppContext.BaseDirectory, "highscore.txt");

    public int Load()
    {
        try
        {
            if (File.Exists(filePath) &&
                int.TryParse(File.ReadAllText(filePath), out int score))
            {
                return score;
            }
        }
        catch (IOException)
        {
           
        }
        return 0;
    }

    public void Save(int score)
    {
        try
        {
            File.WriteAllText(filePath, score.ToString());
        }
        catch (IOException)
        {
            
        }
    }
}
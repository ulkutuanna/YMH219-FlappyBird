namespace FlappyBird;

public class GameState
{
    private const int BaseSpeed = 5;      
    private const int MaxSpeed = 12;     
    private const int PointsPerLevel = 5; 

    public int Score { get; private set; }
    public int Level { get; private set; } = 1;
    public int Speed { get; private set; } = BaseSpeed;
    public bool IsGameOver { get; set; }
    public int HighScore { get; set; }

    public void AddScore()
    {
        Score++;
        Level = Score / PointsPerLevel + 1;
        Speed = Math.Min(BaseSpeed + (Level - 1), MaxSpeed);
    }

    public void Reset()
    {
        Score = 0;
        Level = 1;
        Speed = BaseSpeed;
        IsGameOver = false;
    }
}
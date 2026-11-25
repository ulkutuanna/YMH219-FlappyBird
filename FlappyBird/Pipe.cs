namespace FlappyBird;

public class Pipe
{
    public PictureBox TopPipe { get; }     
    public PictureBox BottomPipe { get; } 
    public int Gap { get; } = 180;         
    public int GapTop { get; private set; } 
    public bool Passed { get; set; }        

    private const int PipeWidth = 70;
    private const int MaxGapShift = 110;    
    private readonly int groundTop;
    private static readonly Random rnd = new Random();

    public int Left => TopPipe.Left;
    public int Right => TopPipe.Right;

    public Pipe(Form form, int startX, int groundTop)
    {
        this.groundTop = groundTop;

        TopPipe = new PictureBox { BackColor = Color.Green, Width = PipeWidth };
        BottomPipe = new PictureBox { BackColor = Color.Green, Width = PipeWidth };

        form.Controls.Add(TopPipe);
        form.Controls.Add(BottomPipe);

        Reset(startX, null);
    }

   
    public void Reset(int x, int? previousGapTop)
    {
        int min = 80;
        int max = groundTop - Gap - 80;

       
        if (previousGapTop.HasValue)
        {
            min = Math.Max(min, previousGapTop.Value - MaxGapShift);
            max = Math.Min(max, previousGapTop.Value + MaxGapShift);
        }

        GapTop = rnd.Next(min, max + 1);

        TopPipe.Left = x;
        TopPipe.Top = 0;
        TopPipe.Height = GapTop;

        BottomPipe.Left = x;
        BottomPipe.Top = GapTop + Gap;
        BottomPipe.Height = groundTop - (GapTop + Gap);

        Passed = false;
    }

    public void Move(int speed)
    {
        TopPipe.Left -= speed;
        BottomPipe.Left -= speed;
    }

    public bool Hits(Rectangle r)
    {
        return TopPipe.Bounds.IntersectsWith(r) || BottomPipe.Bounds.IntersectsWith(r);
    }

    public bool IsOffScreen()
    {
        return Right < 0;
    }
}
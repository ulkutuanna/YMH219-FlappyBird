namespace FlappyBird;

public class Bird
{
    public PictureBox Pic { get; }
    public double VelocityY { get; private set; }
    public double Gravity { get; } = 0.6;
    public double JumpPower { get; } = -9;

    public Bird(PictureBox pic)
    {
        Pic = pic;
    }

    public void Update()
    {
        VelocityY += Gravity;
        Pic.Top += (int)VelocityY;
    }

    public void Jump()
    {
        VelocityY = JumpPower;
    }

    public void Reset(int startTop)
    {
        VelocityY = 0;
        Pic.Top = startTop;
    }
}
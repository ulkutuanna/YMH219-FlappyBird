using System.Drawing.Drawing2D;

namespace FlappyBird;


public static class SpriteFactory
{
    public static Bitmap CreateBird(int w, int h)
    {
        var bmp = new Bitmap(w, h);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;

      
        g.FillEllipse(Brushes.Gold, 2, 3, 32, 24);
        g.DrawEllipse(new Pen(Color.DarkOrange, 2), 2, 3, 32, 24);

   
        g.FillEllipse(Brushes.Orange, 6, 13, 16, 10);

      
        Point[] beak = { new Point(30, 12), new Point(39, 16), new Point(30, 20) };
        g.FillPolygon(Brushes.OrangeRed, beak);

       
        g.FillEllipse(Brushes.White, 21, 5, 11, 11);
        g.FillEllipse(Brushes.Black, 26, 8, 5, 5);

        return bmp;
    }

    public static Bitmap CreateBackground(int w, int h)
    {
        var bmp = new Bitmap(w, h);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;

     
        using (var sky = new LinearGradientBrush(new Rectangle(0, 0, w, h),
                   Color.FromArgb(100, 180, 235), Color.FromArgb(210, 240, 255),
                   LinearGradientMode.Vertical))
        {
            g.FillRectangle(sky, 0, 0, w, h);
        }

        DrawCloud(g, 60, 90);
        DrawCloud(g, 300, 160);
        DrawCloud(g, 180, 300);

        using var hill = new SolidBrush(Color.FromArgb(150, 205, 140));
        g.FillEllipse(hill, -100, h - 220, 400, 300);
        g.FillEllipse(hill, 200, h - 200, 450, 280);

        return bmp;
    }

    private static void DrawCloud(Graphics g, int x, int y)
    {
        g.FillEllipse(Brushes.White, x, y + 10, 70, 30);
        g.FillEllipse(Brushes.White, x + 15, y, 50, 40);
        g.FillEllipse(Brushes.White, x + 40, y + 8, 60, 32);
    }

    public static Bitmap CreatePipe(int w, int h, bool capAtBottom)
    {
        if (h < 1) h = 1;
        var bmp = new Bitmap(w, h);
        using var g = Graphics.FromImage(bmp);

       
        using (var body = new LinearGradientBrush(new Rectangle(0, 0, w, h),
                   Color.FromArgb(60, 140, 40), Color.FromArgb(130, 210, 70),
                   LinearGradientMode.Horizontal))
        {
            body.SetBlendTriangularShape(0.4f);
            g.FillRectangle(body, 0, 0, w, h);
        }

        int capHeight = Math.Min(26, h);
        int capY = capAtBottom ? h - capHeight : 0;
        using (var cap = new LinearGradientBrush(new Rectangle(0, capY, w, capHeight),
                   Color.FromArgb(50, 120, 30), Color.FromArgb(110, 190, 60),
                   LinearGradientMode.Horizontal))
        {
            cap.SetBlendTriangularShape(0.4f);
            g.FillRectangle(cap, 0, capY, w, capHeight);
        }
        g.DrawRectangle(new Pen(Color.FromArgb(30, 80, 20), 2), 0, capY, w - 1, capHeight - 1);

        g.DrawRectangle(new Pen(Color.FromArgb(30, 80, 20), 2), 0, 0, w - 1, h - 1);

        return bmp;
    }

    public static Bitmap CreateGround(int w, int h)
    {
        var bmp = new Bitmap(w, h);
        using var g = Graphics.FromImage(bmp);

        g.Clear(Color.FromArgb(222, 184, 110));                          
        g.FillRectangle(new SolidBrush(Color.FromArgb(110, 190, 60)), 0, 0, w, 16); 
        g.FillRectangle(new SolidBrush(Color.FromArgb(60, 130, 30)), 0, 14, w, 3);  

        using var stripe = new Pen(Color.FromArgb(190, 150, 80), 3);
        for (int x = -20; x < w; x += 30)
        {
            g.DrawLine(stripe, x, h, x + 20, 22);
        }

        return bmp;
    }
}
namespace FlappyBird
{
    public partial class Form1 : Form
    {
        private Bird bird;
        private GameState game = new GameState();

        private HighScoreStorage storage = new HighScoreStorage();
        private List<Pipe> pipes = new List<Pipe>();

        private const int PipeCount = 3;
        private const int PipeSpacing = 320;    
        private const int BirdStartTop = 300;

        public Form1()
        {
            InitializeComponent();

            
            this.ClientSize = new Size(500, 700);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            btnRestart.Click += btnRestart_Click;

           
            picGround.Size = new Size(500, 80);
            picGround.Location = new Point(0, this.ClientSize.Height - picGround.Height);

            bird = new Bird(picBird);

            for (int i = 0; i < PipeCount; i++)
            {
                pipes.Add(new Pipe(this, 500 + i * PipeSpacing, picGround.Top));
            }

            picGround.BringToFront();
            picBird.BringToFront();
            lblScore.BringToFront();
            game.HighScore = storage.Load();
            ResetGame();
        }
        private void UpdateScoreLabel()
        {
            lblScore.Text = $"Skor: {game.Score}  Seviye: {game.Level}  Rekor: {game.HighScore}";
        }


        private void ResetGame()
        {
            game.Reset();
            bird.Reset(BirdStartTop);

           
            for (int i = 0; i < pipes.Count; i++)
            {
                int? previousGapTop = i == 0 ? null : pipes[i - 1].GapTop;
                pipes[i].Reset(500 + i * PipeSpacing, previousGapTop);
            }

            UpdateScoreLabel();
            lblGameOver.Visible = false;
            btnRestart.Visible = false;

            gameTimer.Start();
            this.Focus();
        }

        private void EndGame()
        {
            game.IsGameOver = true;
            gameTimer.Stop();
            if (game.Score > game.HighScore)
            {
                game.HighScore = game.Score;
                storage.Save(game.HighScore);
                UpdateScoreLabel();
            }

            lblGameOver.Left = (this.ClientSize.Width - lblGameOver.Width) / 2;
            lblGameOver.Top = 250;
            btnRestart.Left = (this.ClientSize.Width - btnRestart.Width) / 2;
            btnRestart.Top = 330;

            lblGameOver.Visible = true;
            btnRestart.Visible = true;
            lblGameOver.BringToFront();
            btnRestart.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Update();

            if (picBird.Top < 0)
            {
                picBird.Top = 0;
            }

            Rectangle birdRect = picBird.Bounds;
            birdRect.Inflate(-4, -4);

            foreach (Pipe pipe in pipes)
            {
                pipe.Move(game.Speed);

                if (pipe.IsOffScreen())
                {
                    
                    Pipe last = pipes.OrderByDescending(p => p.Left).First();
                    pipe.Reset(last.Left + PipeSpacing, last.GapTop);
                }

                if (pipe.Hits(birdRect))
                {
                    EndGame();
                    return;
                }

                if (!pipe.Passed && pipe.Right < picBird.Left)
                {
                    pipe.Passed = true;
                    game.AddScore();
                    UpdateScoreLabel();
                }
            }

            if (picBird.Bottom >= picGround.Top)
            {
                EndGame();
            }
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !game.IsGameOver)
            {
                bird.Jump();
            }
        }

        private void btnRestart_Click(object? sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
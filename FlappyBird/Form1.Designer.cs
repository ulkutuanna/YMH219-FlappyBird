namespace FlappyBird
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            picBird = new PictureBox();
            pictGround = new PictureBox();
            lblScore = new Label();
            lblGameOver = new Label();
            btnRestart = new Button();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)picBird).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictGround).BeginInit();
            SuspendLayout();
            // 
            // picBird
            // 
            picBird.BackColor = Color.Yellow;
            picBird.Location = new Point(182, 191);
            picBird.Name = "picBird";
            picBird.Size = new Size(40, 30);
            picBird.TabIndex = 0;
            picBird.TabStop = false;
            // 
            // pictGround
            // 
            pictGround.BackColor = Color.SaddleBrown;
            pictGround.Location = new Point(0, 582);
            pictGround.Name = "pictGround";
            pictGround.Size = new Size(500, 80);
            pictGround.TabIndex = 1;
            pictGround.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lblScore.Location = new Point(0, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(139, 46);
            lblScore.TabIndex = 2;
            lblScore.Text = "Skor : 0 ";
            // 
            // lblGameOver
            // 
            lblGameOver.AutoSize = true;
            lblGameOver.BackColor = Color.Transparent;
            lblGameOver.Font = new Font("Showcard Gothic", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGameOver.ForeColor = Color.Crimson;
            lblGameOver.Location = new Point(292, 255);
            lblGameOver.Name = "lblGameOver";
            lblGameOver.Size = new Size(358, 74);
            lblGameOver.TabIndex = 3;
            lblGameOver.Text = "GAME OVER";
            lblGameOver.Visible = false;
            // 
            // btnRestart
            // 
            btnRestart.Font = new Font("SimSun", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRestart.Location = new Point(312, 332);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(150, 40);
            btnRestart.TabIndex = 4;
            btnRestart.TabStop = false;
            btnRestart.Text = "Restart";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Visible = false;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tick += timer1_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(945, 653);
            Controls.Add(btnRestart);
            Controls.Add(lblGameOver);
            Controls.Add(lblScore);
            Controls.Add(pictGround);
            Controls.Add(picBird);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Flappy Bird ";
            ((System.ComponentModel.ISupportInitialize)picBird).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictGround).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBird;
        private PictureBox pictGround;
        private Label lblScore;
        private Label lblGameOver;
        private Button btnRestart;
        private System.Windows.Forms.Timer gameTimer;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;
using Microsoft.VisualBasic;

namespace Melisska
{
    public partial class Form1 : Form
    {
        private int score = 0;
        private int timeLeft = 10;
        private Timer gameTimer;
        private bool isGameActive = false;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 1000; // 1 second
            gameTimer.Tick += timer1_Tick;

         
        }
        private void ClickButton(object sender, EventArgs e)
        {
            if (!isGameActive)
            {
                isGameActive = true;
                score = 0;
                timeLeft = 10;
                gameTimer.Start();
            }

            score++;
            SystemSounds.Beep.Play();
            UpdateScoreLabel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimeLabel();

            if (timeLeft <= 0)
            {
                gameTimer.Stop();
                isGameActive = false;
                MessageBox.Show($"Вы накликали {score}!");
            }
        }

        private void ScoreLabel_Click(object sender, EventArgs e)
        {

        }
        private void UpdateScoreLabel()
        {
            foreach (Control control in Controls)
            {
                if (control is Label && control.Name == "scoreLabel")
                {
                    control.Text = $"Score: {score}";
                    break;
                }
            }
        }

        private void UpdateTimeLabel()
        {
            foreach (Control control in Controls)
            {
                if (control is Label && control.Name == "timeLabel")
                {
                    control.Text = $"Time: {timeLeft}";
                    break;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Открытие диалогового окна для ввода времени
            string input = Microsoft.VisualBasic.Interaction.InputBox("Введите время игры в секундах:", "Настройки времени", "10");
            if (int.TryParse(input, out int newTime))
            {
                timeLeft = newTime;
                UpdateTimeLabel();
            }
        }

  

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            // Обработка нажатия клавиши пробела
            if (e.KeyCode == Keys.Space)
            {
                score++;
                SystemSounds.Beep.Play();
                UpdateScoreLabel();
            }
        }
        private void TimeSettingsMenuItem_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Введите время игры в секундах:", "Настройки времени", "10");
            if (int.TryParse(input, out int newTime))
            {
                timeLeft = newTime;
                UpdateTimeLabel();
            }
        }

        private void clickButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Это Вы!");
        }
    } }
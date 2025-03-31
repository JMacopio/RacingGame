using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1 : Form
    {
        private Label runner1, runner2, runner3;
        private Button startButton;
        private Random random = new Random();
        private const int finishLine = 500;


        public Form1()
        {
            InitializeComponent();
            // Form setup
            this.Text = "Racing Game";
            this.Size = new Size(600, 300);

            // Create runners
            runner1 = new Label() { Text = "Runner 1", Location = new Point(10, 50), AutoSize = true };
            runner2 = new Label() { Text = "Runner 2", Location = new Point(10, 100), AutoSize = true };
            runner3 = new Label() { Text = "Runner 3", Location = new Point(10, 150), AutoSize = true };

            // Start button
            startButton = new Button() { Text = "Start Race", Location = new Point(10, 200), Size = new Size(100, 30) };
            startButton.Click += StartRace;

            // Add controls to the form
            this.Controls.Add(runner1);
            this.Controls.Add(runner2);
            this.Controls.Add(runner3);
            this.Controls.Add(startButton);

        }

        private void StartRace(object sender, EventArgs e)
        {
            // Disable start button during the race
            startButton.Enabled = false;

            // Create and start racer threads
            Runner racer1 = new Runner(runner1, finishLine, random, this);
            Runner racer2 = new Runner(runner2, finishLine, random, this);
            Runner racer3 = new Runner(runner3, finishLine, random, this);

            new Thread(racer1.Run).Start();
            new Thread(racer2.Run).Start();
            new Thread(racer3.Run).Start();
        }

        public void ShowWinner(string winner)
        {
            Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(winner + "wins the race!");
                startButton.Enabled = true;
            });
        }
    }
}

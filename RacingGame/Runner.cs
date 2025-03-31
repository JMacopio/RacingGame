using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public class Runner
    {
        private Label runnerLabel;
        private int finishLine;
        private Random random;
        private Form1 mainForm;

        public Runner(Label runnerLabel, int finishLine, Random random, Form1 mainForm)
        {
            this.runnerLabel = runnerLabel;
            this.finishLine = finishLine;
            this.random = random;
            this.mainForm = mainForm;
        }

        public void Run()
        {
            while (runnerLabel.Location.X < finishLine)
            {
                mainForm.Invoke((MethodInvoker)delegate
                {
                    runnerLabel.Location = new Point(runnerLabel.Location.X + random.Next(1, 10), runnerLabel.Location.Y);
                    if (runnerLabel.Location.X >= finishLine)
                    {
                        mainForm.ShowWinner(runnerLabel.Text);
                    }
                });
                Thread.Sleep(50);
            }
        }
    }
}

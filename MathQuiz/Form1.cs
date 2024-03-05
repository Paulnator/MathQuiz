using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        // Addition problem variables
        int addend1;
        int addend2;

        // Subtraction problem variables
        int minuend;
        int subtrahend;

        // Multiplication problem variables
        int multiplicand;
        int multiplier;

        // Division problem variables
        int dividend;
        int divisor;

        // Timer variables
        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

         public void StartTheQuiz()
         {
            DrawAdditionProblem();

            DrawSubtractionProblem();

            DrawMultiplicationProblem();

            DrawDivisionProblem();

            StartTimer();
         }

        public void DrawAdditionProblem()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;
        }

        public void DrawSubtractionProblem()
        {
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            diffrence.Value = 0;
        }

        public void DrawMultiplicationProblem()
        {
            multiplicand = randomizer.Next(1, 11);
            multiplier = randomizer.Next(1, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
        }

        public void DrawDivisionProblem()
        {
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLable.BackColor = Color.LightGreen;
            StartTheQuiz();
            startButton.Enabled = false;
        }

        public bool CheckTheAnwser()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == diffrence.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnwser())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!," +
                                "Congratulations !");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {              
                timeLeft = timeLeft - 1;
                timeLable.Text = timeLeft + "Seconds";

                if (timeLeft < 10)
                {
                    timeLable.BackColor = Color.Red;
                }              
            }
            else
            {
                timer1.Stop();
                timeLable.Text = "Time's up";
                MessageBox.Show("You didn't finish in time", "Try Again!");
                sum.Value = addend1 + addend2;
                diffrence.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }
        public void StartTimer()
        {
            timeLeft = 45;
            timeLable.Text = "45 seconds";
            timer1.Start();       
        }
        
        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }

}

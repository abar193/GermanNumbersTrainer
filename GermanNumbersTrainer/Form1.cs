using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;

namespace GermanNumbersTrainer
{
    public partial class MainForm : Form
    {
        Sounds.SoundSequenceGenerator ssg;

        public MainForm()
        {
            InitializeComponent();
            ssg = new Sounds.SoundSequenceGenerator();
            ssg.SequenceFinished += new Sounds.SequenceFinishedDelegate(ssg_SequenceFinished);
            ssg.SequenceFinished += new Sounds.SequenceFinishedDelegate(ssg_SequenceFinished2);
            
            doubleEnabled = commasCheckBox.Checked;
            randomGenerator = new Random();
        }

        /* * * Logic * * */

        bool doubleEnabled;
        double doubleNumber;
        int score;

        List<double> pastNumbers;

        const int maxSequences = 10;
        const int maxPositionsInNumber = 7;

        void userEnteredNumber(String input) 
        {
            Console.WriteLine(input);
            answersListBox.Items.Add(input);
            if (input == doubleNumber.ToString())
                marksListBox.Items.Add("+");
            else 
                marksListBox.Items.Add("-");

            displayPairOfAnswerAndNumber(input, doubleNumber);

            score++;
            if (score < maxSequences)
                generateNewNumber();
            else
                stopTrainingDesignActions();
        }

        void startRound()
        {
            score = 0;

            marksListBox.Items.Clear();
            answersListBox.Items.Clear();
            inputTextBox.Enabled = true;

            if (pastNumbers == null)
                pastNumbers = new List<double>(10);
            pastNumbers.Clear();

            generateNewNumber();
        }

        void generateNewNumber()
        {
            doubleNumber = randomGenerator.NextDouble();
            int addOffset = 0;
            if (doubleEnabled)
                addOffset = randomGenerator.Next(4);

            doubleNumber *= Math.Pow(10, maxPositionsInNumber + addOffset);
            doubleNumber = Math.Truncate(doubleNumber);

            if (doubleEnabled)
                doubleNumber /= Math.Pow(10, addOffset);

            inputTextBox.Text = "";
            pastNumbers.Add(doubleNumber);

            ssg.play(doubleNumber);
        }
                
        void showHistoryAtIndex(int index)
        {
            try {
                displayPairOfAnswerAndNumber((string)answersListBox.Items[index], pastNumbers[index]);
            } catch (Exception) {
                Console.WriteLine("EXCEPTION. Somehow I passed wrong index to Form1.showHistoryAtIndex");
            }
        }

        /* * * Events & UI * * */

        Random randomGenerator;
        bool roundStarted = false;

        void displayPairOfAnswerAndNumber(String answer, double number) 
        {
            userAnswerLabel.Text = answer;
            corectAnswerLabel.Text = (number.ToString() == answer) ? "-||-" : number.ToString();
        }

        void stopTrainingDesignActions()
        {
            startButton.Text = "Start";
            roundStarted = false;
            playSoundAgain.Enabled = false;
            ssg.stop();
            inputTextBox.Enabled = false;
        }

        void ssg_SequenceFinished2() 
        {
            Console.WriteLine("Form:SequenceFinished#2");
        }

        void ssg_SequenceFinished() 
        {
            Console.WriteLine("Form:SequenceFinished");
        }

        private void startButton_Click(object sender, EventArgs e) 
        {
            if(!roundStarted) {
                startButton.Text = "Stop";     
                roundStarted = true;
                startRound();
                playSoundAgain.Enabled = true;
            } else {
                stopTrainingDesignActions();
            }
        }

        private void playSoundAgain_Click(object sender, EventArgs e) 
        {
            ssg.play(doubleNumber);
        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)13)
			{
                userEnteredNumber(inputTextBox.Text);
			}
        }

        private void commasCheckBox_CheckedChanged(object sender, EventArgs e) {
            doubleEnabled = commasCheckBox.Checked;
        }

        private void answersListBox_SelectedIndexChanged(object sender, EventArgs e) {
            marksListBox.SelectedIndex = answersListBox.SelectedIndex;
            showHistoryAtIndex(answersListBox.SelectedIndex);
        }

        private void marksListBox_SelectedIndexChanged(object sender, EventArgs e) {
            answersListBox.SelectedIndex = marksListBox.SelectedIndex;
            showHistoryAtIndex(marksListBox.SelectedIndex);
        }

    }
}

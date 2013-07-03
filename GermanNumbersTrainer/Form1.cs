using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        const int maxSequences = 10;
        const int maxPositionsInNumber = 7;

        void userEnteredNumber(String input) 
        {
            Console.WriteLine(input);
        }

        void startRound()
        {
            score = 0;
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

            Console.WriteLine(doubleNumber);
            ssg.play(doubleNumber);
        }
                
        /* * * Events * * */

        Random randomGenerator;

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
            startRound();
        }

        private void playSoundAgain_Click(object sender, EventArgs e) 
        {

        }

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e) 
        {
            if (e.KeyChar == (char)13)
			{
                userEnteredNumber(inputTextBox.Text);
			}
        }

    }
}

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
        public MainForm()
        {
            InitializeComponent();
            ssg = new Sounds.SoundSequenceGenerator();
            ssg.SequenceFinished += new Sounds.SequenceFinishedDelegate(ssg_SequenceFinished);
            ssg.SequenceFinished += new Sounds.SequenceFinishedDelegate(ssg_SequenceFinished2);
        }

        void ssg_SequenceFinished2() {
            Console.WriteLine("Form:SequenceFinished#2");
        }

        void ssg_SequenceFinished() {
            Console.WriteLine("Form:SequenceFinished");
        }

        Sounds.SoundSequenceGenerator ssg;

        private void startButton_Click(object sender, EventArgs e) {
            ssg.play(15);
            Console.WriteLine("===");
            /*ssg.play(123000456.070);
            Console.WriteLine("===");
            ssg.play(201021210.000);
            Console.WriteLine("===");
            ssg.play(0.142);
            Console.WriteLine("===");*/
        }

    }
}

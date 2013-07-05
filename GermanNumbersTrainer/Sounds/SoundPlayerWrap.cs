using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Media;

namespace GermanNumbersTrainer.Sounds
{
    public delegate void SPWFinishedDelegate();

    public class SoundPlayerWrap
    {
        /* * * STATIC * * */
        private static SoundPlayerWrap myinstance = null;
 
        public static SoundPlayerWrap instance()
        {
            if (myinstance != null) return myinstance;
            else
            {
                myinstance = new SoundPlayerWrap();
                return myinstance;
            }
        }

        /* * * OBJECT * * */

        public SPWFinishedDelegate onFinish;

        public void playSequence()
        {
            nextSoundInSequence();
        }

        private void nextSoundInSequence()
        {
            String s = parentGenerator.nextFile();
            
            if(s != null) { 
                myPlayer.SoundLocation = s;
                
                if(!myWorker.IsBusy)  {
                    myWorker.RunWorkerAsync();
                } else {
                    myWorker.CancelAsync();
                }
            } else {
                if(onFinish != null) 
                    onFinish();
            }
            
        }

        public void stopPlaying()
        {

        }

        private SoundPlayer myPlayer;
        private SoundSequenceGeneratorInterface parentGenerator;

        public void setParentGenerator(SoundSequenceGeneratorInterface paramGenerator)
        {
            parentGenerator = paramGenerator;
        }

        private SoundPlayerWrap()
        {
            Console.WriteLine("ABCDEFG");

            myPlayer = new SoundPlayer();
            
            myPlayer.LoadCompleted += this.player_LoadCompleted;

            myWorker = new System.ComponentModel.BackgroundWorker();
            myWorker.DoWork += this.backgroundWorker1_DoWork;
            myWorker.RunWorkerCompleted += this.backgroundWorker1_RunWorkerCompleted;
            myWorker.WorkerSupportsCancellation = true;

            Console.WriteLine("HIJKLMNOP");
        }

        private void player_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Load completed");
        }

        private void playerStopped()
        {
            this.playSequence();
        }

        private void playerCanceledAndStartPlayingNew()
        {
            if(!myWorker.IsBusy && parentGenerator.isPlaying())  {
                myWorker.RunWorkerAsync();
            }
        }

        /* * * BACKGROUND OPERATIONS * * */

        BackgroundWorker myWorker;

        private void playInBackground()
        {
            Console.WriteLine(myPlayer.SoundLocation);
            myPlayer.SoundLocation = @"../../Sounds/winner.wav";
            myPlayer.PlaySync();
            //System.Threading.Thread.Sleep(1500);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;

            playInBackground();

            // If the operation was canceled by the user,  
            // set the DoWorkEventArgs.Cancel property to true. 
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {   
            if (e.Cancelled)
            {
                Console.WriteLine("Operation was canceled");
                playerCanceledAndStartPlayingNew();
            }
            else if (e.Error != null)
            {
                string msg = String.Format("An error occurred: {0}", e.Error.Message);
                Console.WriteLine(msg);
            }
            else
            {
                // The operation completed normally. 
                playerStopped();
            }
            
        }
    }
}

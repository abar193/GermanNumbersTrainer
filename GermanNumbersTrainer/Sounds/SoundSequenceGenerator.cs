using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GermanNumbersTrainer.Sounds
{
    public delegate void SequenceFinishedDelegate();

    public class SoundSequenceGenerator:SoundSequenceGeneratorInterface
    {
        public event SequenceFinishedDelegate SequenceFinished;    

        public SoundSequenceGenerator()
        {
            spw = SoundPlayerWrap.instance();
            spw.onFinish = new SPWFinishedDelegate(notifyFinished);
            spw.setParentGenerator(this);
        }

        /* * * USED BY FORM * * */
        private bool playing = false;

        public bool isPlaying()
        {
            return playing;
        }

        //TODO: this
        public void stop()
        {
            playing = false;
            spw.stopPlaying();
        }

        public void play(String s)
        {
            throw new NotImplementedException();
        }

        public void play(double r)
        {
            Console.WriteLine("Playing float " + r.ToString());
            initializeSequence();

            appendDecimals((long)(Math.Round(r * 1000, 0) - ((long)r) * 1000));
            createIntegerPart((long)r);
            spw.playSequence();
        }

        public void play(int i)
        {
            initializeSequence();
            createIntegerPart(i);

            spw.playSequence();
        }

        private void notifyFinished()
        {
            playing = false;
            if (SequenceFinished != null)
                SequenceFinished();
        }

        /* * * SEQUENCE GENERATING * * */

        private void initializeSequence()
        {
            if (sequence == null) {
                sequence = new List<string>(10); 
            } else {
                sequence.Clear();
            }
        }

        private List<String> sequence = null;
        private string FilePrefix = @"../../Sounds/SoundFiles/";

        private readonly string[] Parts = {"Tausend.wav", "Million.wav", "Milliarde.wav"};

        private void appendPronounceOfThreeDiggits(long number) 
        {
            long hundred, ten, unit;
            unit = number % 10;
            number /= 10;
            ten = number % 10;
            number /= 10;
            hundred = number % 10;

            if(ten != 0) {
                if(ten == 1) {
                    if (unit == 0) //10
                        sequence.Add("10.wav");
                    else if (unit < 3) //11, 12
                        sequence.Add((10 + unit).ToString() + ".wav");
                    else { //13, 14, ..., 19
                        sequence.Add("zehn.wav");
                        sequence.Add(unit.ToString() + ".wav");
                    }
                } else {
                    sequence.Add((ten * 10).ToString() + ".wav");
                    if (unit != 0)
                        sequence.Add("und.wav");
                }
            }

            if (unit != 0 && ten != 1) sequence.Add(unit.ToString() + ".wav");
            if (hundred != 0) {
                sequence.Add("100.wav");
                if(hundred != 1) sequence.Add((hundred).ToString() + ".wav");
            }

        }

        private void createIntegerPart(long number)
        {

            int i = -1;

            if (number == 0)
                sequence.Add("0");

            while(number > 0) {                
                try {
                    if (i >= 0 & (number % 1000 != 0))
                        sequence.Add(Parts[i]);
                    i++;
                } catch (Exception) {
                    Console.WriteLine("Error in SSG.createIntegerPart(int). Probably, the param 'number' is more or equal for 10^12. Fix that by adding more sound files and more elements in Parts array");
                }

                appendPronounceOfThreeDiggits(number % 1000);

                number /= 1000;
            }
            
        }

        private void appendDecimals(long decimals)
        {
            bool wasAnyDiggit = false;

            while(decimals > 0) {
                long digg = decimals % 10;
                decimals /= 10;
                if(digg != 0 | wasAnyDiggit) 
                {
                    wasAnyDiggit = true;
                    sequence.Add(digg.ToString() + ".wav");
                }
            }

            if (wasAnyDiggit)
                sequence.Add("Comma.wav");
        }

        /* * * USED BY SPW * * */
        private SoundPlayerWrap spw;

        public String nextFile()
        {
            if (sequence.Count != 0) {
                string retVal = sequence[sequence.Count - 1];
                sequence.RemoveAt(sequence.Count - 1);
                return FilePrefix + retVal;
            } else
                return null;
        }

        public void allDone()
        {
            Console.WriteLine("SSG:Done");
        }

        public void fileError()
        {
            Console.WriteLine("SSG:Error");
        }

    }
}

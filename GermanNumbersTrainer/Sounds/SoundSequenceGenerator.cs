using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GermanNumbersTrainer.Sounds
{
    public class SoundSequenceGenerator:SoundSequenceGeneratorInterface
    {
        public SoundSequenceGenerator()
        {
            spw = SoundPlayerWrap.instance();
            spw.setParentGenerator(this);
        }

        /* * * USED BY FORM * * */
        private bool playing = false;

        public bool isPlaying { get { return playing; } }

        public void stop()
        {
            playing = false;
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
        private string FilePrefix = "";

        private readonly string[] Parts = {"Tausend", "Million", "Milliard"};

        private void appendPronounceOfThreeDiggits(long number) 
        {
            long hundred, ten, unit;
            unit = number % 10;
            number /= 10;
            ten = number % 10;
            number /= 10;
            hundred = number % 10;

            if(ten != 0) {
                sequence.Add((ten * 10).ToString());
                if (unit != 0)
                    sequence.Add("und ");
            }

            if (unit != 0) sequence.Add(unit.ToString());
            if (hundred != 0) sequence.Add((hundred * 100).ToString());

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
                    sequence.Add(digg.ToString());
                }
            }

            if (wasAnyDiggit)
                sequence.Add("Comma");
        }

        /* * * USED BY SPW * * */
        private SoundPlayerWrap spw;

        public String nextFile()
        {
            if (sequence.Count != 0) {
                string retVal = sequence[sequence.Count - 1];
                sequence.RemoveAt(sequence.Count - 1);
                return retVal;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GermanNumbersTrainer.Sounds
{
    public interface SoundSequenceGeneratorInterface
    {
        String nextFile();
        void allDone();
        void fileError();
        bool isPlaying();
    }
}

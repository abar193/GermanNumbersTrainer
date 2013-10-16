using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GermanNumbersTrainer.Sounds;

namespace PlayingSoundsTests
{
    [TestClass]
    public class SoundPlayingTests
    {
        [TestMethod]
        public void EmptyStringFile()
        {
            SoundPlayerWrap spw = SoundPlayerWrap.instance();
            spw.forcePlay("");
        }

        [TestMethod]
        public void nullPassed()
        {
            SoundPlayerWrap spw = SoundPlayerWrap.instance();
            spw.forcePlay(null);
        }

        [TestMethod]
        public void wrongNamePassed()
        {
            SoundPlayerWrap spw = SoundPlayerWrap.instance();
            spw.forcePlay(@"C:\this is an example of a wrong path\");
        }
    }
}

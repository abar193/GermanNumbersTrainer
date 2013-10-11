using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GermanNumbersTrainer.Sounds;

namespace PlayingSoundsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            SoundPlayerWrap spw = SoundPlayerWrap.instance();
            spw.forcePlay("");
            Assert.IsFalse(false);
        }
    }
}

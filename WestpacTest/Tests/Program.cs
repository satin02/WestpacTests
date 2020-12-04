using NUnit.Framework;

using WestpacTest.Global;

using System;

namespace WestpacTest
{
    public class Program
    {
        [TestFixture]
        class KiwiSaver: Global.Base
        {
           
            [Test]

            public void CheckingInfoIcons()
            {
              
                KiwisaverCalculators KSCalc = new KiwisaverCalculators();
                KSCalc.CheckInformationIcons();
               
            }
            [Test]

            public void KiwiSaverCalculationsEmployed()
            {
                KiwisaverCalculators KSCalc = new KiwisaverCalculators();
                KSCalc.RetirementCalculationsEmployed();

            }
            [Test]
            public void KiwiSaverCalculationsSelfEmployed()
            {
                KiwisaverCalculators KSCalc = new KiwisaverCalculators();
                KSCalc.RetirementCalculationsSelfemployed();

            }
            [Test]
            public void KiwiSaverCalculationsNotEmployed()
            {
                KiwisaverCalculators KSCalc = new KiwisaverCalculators();
                KSCalc.RetirementCalculationsNotemployed();

            }
        }
    }
}

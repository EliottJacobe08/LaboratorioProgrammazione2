using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppSpesaCorrezioneTest
{
    public class Tests
    {
        private WindowsDriver _driver;
  
            [SetUp]
            public void Setup()
            {
                var options = new AppiumOptions();

                options.PlatformName = "Windows";
                options.AutomationName = "Windows";
                options.DeviceName = "WindowsPC";
                options.App = "com.companyname.appspese_9zz4h110yvjzm!App";

                options.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
                options.AddAdditionalAppiumOption("ms:waitForAppLaunch", "10");

            var serverUri = new Uri("http://127.0.0.1:4723/");
            _driver = new WindowsDriver(serverUri, options);
        }

        [Test]
        public void Test_verificaTitoloApp()
        {

            Assert.That(_driver.Title, Is.EqualTo("AppSpeseCorrezione").Or.Contain("LE MIE SPESE")); 
        }

        [Test]
        public void Test_Inserimento()
        {
            //thread permette la programmazione parallela
            System.Threading.Thread.Sleep(3000);

            var inputNome = _driver.FindElement(MobileBy.AccessibilityId("EntNomeLista"));
            inputNome.Click();
            inputNome.Clear();
            inputNome.SendKeys("Spesa Aprile");

        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace HelloAppiumTest
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
            options.App = "com.companyname.helloappium_9zz4h110yvjzm!App";

            options.AddAdditionalAppiumOption("ms:experimental-webdriver", true);
            options.AddAdditionalAppiumOption("ms:waitForAppLaunch", "10");

            var serverUri = new Uri("http://127.0.0.1:4723/");
            _driver = new WindowsDriver(serverUri, options);
        }

        [Test]
        public void Test1()
        {

            var bottone = _driver.FindElement(MobileBy.AccessibilityId("CounterBtn"));

            Assert.That(bottone.Text, Is.EqualTo("Click me"));


            bottone.Click();
            System.Threading.Thread.Sleep(500); // Pausa tecnica per l'aggiornamento UI


            Assert.That(bottone.Text, Does.Contain("1 time"));


            bottone.Click();
            System.Threading.Thread.Sleep(500);


            Assert.That(bottone.Text, Does.Contain("2 times"));
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Close();
            _driver?.Dispose();
        }

    }
}
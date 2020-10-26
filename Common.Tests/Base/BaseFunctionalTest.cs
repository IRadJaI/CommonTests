using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Common.Tests.Base
{
    [TestClass]
    public class BaseFunctionalTest {

#if DEBUG
        const string ENV_VARIABLE = "Development";
#else
        const string ENV_VARIABLE = "Production";
#endif
        public IWebDriver WebDriver;
        public ISettings Settings;
        public TestContext TestContext { get; set; }
        public BaseFunctionalTest() {
            IConfigurationBuilder builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(string.Format("Settings.{0}.json", ENV_VARIABLE));
            Settings settings = new Settings();
            IConfigurationRoot settingRawRoot = builder.Build();
            settingRawRoot.Bind(settings);
            SetSettings(settings);
        }
        public void SetSettings(ISettings settings)
        {
            Settings = settings;
        }
        [TestInitialize]
        public void Setup()
        {
            WebDriver = new ChromeDriver("./");
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl(Settings.TestUrl);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(4);
        }
        [TestCleanup]
        public void TestTearDown() {
            TearDown(() => { });
        }
        public void TearDown(Action cleanup)
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                ((ITakesScreenshot)WebDriver).GetScreenshot()
                    .SaveAsFile(string.Format("{0}\\{1}-ErrorScreenshot.png", Directory.GetCurrentDirectory(), TestContext.TestName), ScreenshotImageFormat.Png);
            }
            cleanup();
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}

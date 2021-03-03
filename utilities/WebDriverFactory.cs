using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TestAssignmentProject.utilities
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;
        public static IWebDriver getDriver()
        {
            //String browser = ConfigurationManager.AppSettings["Browser"];

            ConfigReader.GetGlobalConfigs();

            if (driver == null)
            {
                driver = setDriver();
            }
            return driver;
        }

        private static IWebDriver setDriver(String browser = "chrome")
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    return InitializeChromeDriver();
                //case "firefox":
                //    return new FirefoxDriver();
                //case "ie":
                //    return new InternetExporerDriver();
                default:
                    return new ChromeDriver();
            }
        }

        private static IWebDriver InitializeChromeDriver()
        {
            try
            {
                var options = new ChromeOptions();
                options.AddArguments(
                     "--disable-extensions",
                     "--disable-features",
                     "--disable-popup-blocking",
                     "--disable-settings-window",
                     "--disable-impl-side-painting",
                     "--enable-javascript",
                     "--start-maximized",
                     "--no-sandbox",
                     //"--headless",
                     "--disable-gpu",
                     "--dump-dom",
                     "test-type=browser",
                     "disable-infobars",
                      "test-type",
                     "--enable-automation"
                     );
                //log.Info("Chrome driver initiated");
                return new ChromeDriver(options);
            }
            catch (Exception e)
            {
                //log.Info("Failed to launch chrome driver " + e.Message);
                closeDriver();
                driver = null;
                return driver;
            }
        }

        public static void closeDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
                //log.Info("Browser/ driver closed.");
            }

        }

    }
}

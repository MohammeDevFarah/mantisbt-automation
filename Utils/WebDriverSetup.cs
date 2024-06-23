using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MantisAutomation.Utils
{
    public class WebDriverSetup
    {
        public IWebDriver InitializeWebDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return new ChromeDriver(options);
        }
    }
}
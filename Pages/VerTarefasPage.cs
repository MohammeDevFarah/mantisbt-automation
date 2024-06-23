using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class VerTarefasPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //menu "Ver Tarefas"
        private readonly By _verTarefasMenu = By.XPath("//i[@class='menu-icon fa fa-list-alt']");

        public VerTarefasPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Método para clicar no menu "Ver Tarefas"
        public void ClickVerTarefasMenu()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_verTarefasMenu));
            _driver.FindElement(_verTarefasMenu).Click();
        }
    }
}

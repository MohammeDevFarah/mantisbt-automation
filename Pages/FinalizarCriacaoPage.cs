using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class FinalizarCracaoPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //botão "Finalizar"
        private readonly By _finalizarButton = By.CssSelector("#report_bug_form > div > div.widget-body.dz-clickable > div.widget-toolbox.padding-8.clearfix > input"); 

        public FinalizarCracaoPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20)); 
        }

        // Método para clicar no botão "Finalizar"
        public void ClickFinalizarButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_finalizarButton));
            _driver.FindElement(_finalizarButton).Click();
        }
    }
}

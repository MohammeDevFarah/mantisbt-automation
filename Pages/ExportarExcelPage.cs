using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class ExportarExcelPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //botão "Exportação para Excel"
        private readonly By _exportarExcelButton = By.XPath("//a[normalize-space()='Exportação para Excel']");
        //checkboxes das tarefas
        private readonly By _tarefaCheckbox1 = By.XPath("//tbody/tr[1]/td[1]/div[1]/label[1]/span[1]");
        private readonly By _tarefaCheckbox2 = By.XPath("//tbody/tr[5]/td[1]/div[1]/label[1]/span[1]");
        private readonly By _tarefaCheckbox3 = By.XPath("//tbody/tr[3]/td[1]/div[1]/label[1]/span[1]");

        public ExportarExcelPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Método para selecionar ao menos 3 tarefas
        public void SelecionarTarefas()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_tarefaCheckbox1));
            _driver.FindElement(_tarefaCheckbox1).Click();
            _driver.FindElement(_tarefaCheckbox2).Click();
            _driver.FindElement(_tarefaCheckbox3).Click();
        }

        // Método para clicar no botão "Exportação para Excel"
        public void ClickExportarExcelButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_exportarExcelButton));
            _driver.FindElement(_exportarExcelButton).Click();
        }
    }
}

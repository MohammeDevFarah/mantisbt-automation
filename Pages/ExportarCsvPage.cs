using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class ExportarCsvPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //botão "Exportar para Arquivo CSV"
        private readonly By _exportarCsvButton = By.XPath("//a[normalize-space()='Exportar para Arquivo CSV']");
        //checkboxes das tarefas
        private readonly By _tarefaCheckbox1 = By.XPath("//tbody/tr[4]/td[1]/div[1]/label[1]/span[1]");
        private readonly By _tarefaCheckbox2 = By.XPath("//tbody/tr[6]/td[1]/div[1]/label[1]/span[1]");
        private readonly By _tarefaCheckbox3 = By.XPath("//tbody/tr[2]/td[1]/div[1]/label[1]/span[1]");

        public ExportarCsvPage(IWebDriver driver)
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

        // Método para clicar no botão "Exportar para Arquivo CSV"
        public void ClickExportarCsvButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_exportarCsvButton));
            _driver.FindElement(_exportarCsvButton).Click();
        }
    }
}

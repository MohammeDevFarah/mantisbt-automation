using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class ImprimirTarefasPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //botão "Imprimir Tarefas"
        private readonly By _imprimirTarefasButton = By.XPath("//a[normalize-space()='Imprimir Tarefas']");
        //checkboxes das tarefas
        private readonly By _tarefaCheckbox1 = By.XPath("//tbody/tr[1]/td[1]/div[1]/label[1]/span[1]");
        private readonly By _tarefaCheckbox2 = By.XPath("//tbody/tr[4]/td[1]/div[1]/label[1]/span[1]");
        private readonly By _tarefaCheckbox3 = By.XPath("//tbody/tr[6]/td[1]/div[1]/label[1]/span[1]");
        //botão de exportação para Word
        private readonly By _exportarWordButton = By.XPath("//i[@title='Word 2000']");
        //botão de abrir no Word Web
        private readonly By _openInWordWebButton = By.XPath("//i[@title='Word View']");

        public ImprimirTarefasPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        // Método para clicar no botão "Imprimir Tarefas"
        public void ClickImprimirTarefasButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_imprimirTarefasButton));
            _driver.FindElement(_imprimirTarefasButton).Click();
        }

        // Método para selecionar ao menos 3 tarefas
        public void SelecionarTarefas()
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(_tarefaCheckbox1));
            _driver.FindElement(_tarefaCheckbox1).Click();
            _driver.FindElement(_tarefaCheckbox2).Click();
            _driver.FindElement(_tarefaCheckbox3).Click();
        }

        // Método para clicar no botão de exportação para Word
        public void ClickExportarWordButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_exportarWordButton));
            _driver.FindElement(_exportarWordButton).Click();
        }

        // Método para clicar no botão de abrir no Word Web
        public void ClickOpenInWordWebButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_openInWordWebButton));
            _driver.FindElement(_openInWordWebButton).Click();
        }
    }
}

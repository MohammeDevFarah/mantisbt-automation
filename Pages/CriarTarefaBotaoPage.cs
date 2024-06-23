using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class CriarTarefaBotaoPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        //botão "Criar Tarefas"
        private readonly By _criarTarefasButton = By.CssSelector("#navbar-container > div.navbar-buttons.navbar-header.navbar-collapse.collapse > ul > li.hidden-sm.hidden-xs > div > a");
        private readonly By _detalhesRelatorioText = By.XPath("//*[@id='report_bug_form']/div/div[1]/h4");

        public CriarTarefaBotaoPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        // Método para clicar no botão "Criar Tarefas"
        public void ClickCriarTarefasButton()
        {
            _wait.Until(ExpectedConditions.ElementToBeClickable(_criarTarefasButton));
            _driver.FindElement(_criarTarefasButton).Click();
        }

        // Método para verificar se a tela de criação de tarefas foi carregada corretamente
        public bool IsCriarTarefaPageLoaded()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(_detalhesRelatorioText));
                return _driver.FindElement(_detalhesRelatorioText).Displayed;
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine("Elemento não encontrado: " + ex.Message);
                return false;
            }
            catch (WebDriverTimeoutException ex)
            {
                Console.WriteLine("Tempo esgotado ao esperar pelo elemento: " + ex.Message);
                return false;
            }
        }
    }
}

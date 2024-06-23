using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class PreencherTarefaPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _categoriaSelect = By.XPath("//select[@id='category_id']");
        private readonly By _categoriaOption = By.XPath("//*[@id='category_id']/option[2]");
        private readonly By _frequenciaSelect = By.XPath("//*[@id='reproducibility']");
        private readonly By _frequenciaOption = By.XPath("//*[@id='reproducibility']/option[2]");
        private readonly By _gravidadeSelect = By.XPath("//*[@id='severity']");
        private readonly By _gravidadeOption = By.XPath("//*[@id='severity']/option[6]");
        private readonly By _prioridadeSelect = By.XPath("//*[@id='priority']");
        private readonly By _prioridadeOption = By.XPath("//*[@id='priority']/option[4]");
        private readonly By _resumoField = By.XPath("//input[@id='summary']");
        private readonly By _descricaoField = By.XPath("//textarea[@id='description']");
        private readonly By _passosParaReproduzirField = By.XPath("//textarea[@id='steps_to_reproduce']");
        private readonly By _informacoesAdicionaisField = By.XPath("//textarea[@id='additional_info']");

        public PreencherTarefaPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        }

        public void PreencherDadosDaTarefa()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(_resumoField));
                _driver.FindElement(_resumoField).SendKeys("Bug no Menu 'Minha Visão' não Carrega Itens");

                _driver.FindElement(_descricaoField).SendKeys("Ao acessar o menu 'Minha Visão', os itens configurados pelo usuário não são carregados corretamente. " +
                    "O sistema apresenta uma tela em branco ou um carregamento infinito, impedindo a visualização dos dados.");

                _driver.FindElement(_passosParaReproduzirField).SendKeys("1. Faça login no sistema.\n" +
                    "2. Navegue até o menu 'Minha Visão'.\n" +
                    "3. Observe que os itens configurados não são carregados e a tela permanece em branco ou com carregamento infinito.\n" +
                    "4. Tente atualizar a página e verifique se o problema persiste.");

                _driver.FindElement(_informacoesAdicionaisField).SendKeys("O problema parece ocorrer apenas para usuários com muitas configurações personalizadas no menu 'Minha Visão'. " +
                    "Outros menus e funcionalidades estão funcionando corretamente. Suspeita-se que o problema esteja relacionado à quantidade de dados que o menu 'Minha Visão' tenta carregar simultaneamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao preencher dados da tarefa: {ex.Message}");
                throw;
            }
        }

        public void SelecionarCategoria()
        {
            SelecionarOpcaoDropdown(_categoriaSelect, _categoriaOption);
        }

        public void SelecionarFrequencia()
        {
            SelecionarOpcaoDropdown(_frequenciaSelect, _frequenciaOption);
        }

        public void SelecionarGravidade()
        {
            SelecionarOpcaoDropdown(_gravidadeSelect, _gravidadeOption);
        }

        public void SelecionarPrioridade()
        {
            SelecionarOpcaoDropdown(_prioridadeSelect, _prioridadeOption);
        }

        // Método auxiliar para selecionar uma opção em um dropdown
        private void SelecionarOpcaoDropdown(By selectLocator, By optionLocator)
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementToBeClickable(selectLocator));
                _driver.FindElement(selectLocator).Click();
                _wait.Until(ExpectedConditions.ElementToBeClickable(optionLocator));
                _driver.FindElement(optionLocator).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao selecionar opção no dropdown: {ex.Message}");
                throw;
            }
        }
    }
}

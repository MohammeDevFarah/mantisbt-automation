using NUnit.Framework;
using OpenQA.Selenium;
using MantisAutomation.Pages;
using MantisAutomation.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading;

namespace MantisAutomation.Tests
{
    public class CriarTarefaTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private CriarTarefaBotaoPage _criarTarefaBotaoPage;
        private PreencherTarefaPage _preencherTarefaPage;
        private FinalizarCracaoPage _finalizarCracaoPage;
        private WebDriverSetup _webDriverSetup;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<CriarTarefaTests>(); // Acessa as credenciais armazenadas

            _configuration = builder.Build();

            _webDriverSetup = new WebDriverSetup();
            _driver = _webDriverSetup.InitializeWebDriver();
            _loginPage = new LoginPage(_driver);
            _criarTarefaBotaoPage = new CriarTarefaBotaoPage(_driver);
            _preencherTarefaPage = new PreencherTarefaPage(_driver);
            _finalizarCracaoPage = new FinalizarCracaoPage(_driver);
            NavigateToLoginPage();
        }

        private void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br");
            Console.WriteLine("Navigated to login page.");
        }

        [Test]
        public void TestCriarTarefa()
        {
            string username = _configuration["Mantis:Username"];
            string password = _configuration["Mantis:Password"];

            Console.WriteLine("Attempting to log in...");
            _loginPage.Login(username, password);

            // Espera 8 segundos
            Thread.Sleep(8000);
            Console.WriteLine("Waited for 8 seconds.");

            // Clica no botão "Criar Tarefas"
            Console.WriteLine("Clicking 'Criar Tarefas' button...");
            _criarTarefaBotaoPage.ClickCriarTarefasButton();

            // Verifica se a tela de criação de tarefas foi carregada corretamente
            Console.WriteLine("Verifying if 'Criar Tarefa' page loaded...");
            bool isPageLoaded = _criarTarefaBotaoPage.IsCriarTarefaPageLoaded();

            // Adiciona asserção para verificar se a tela foi carregada corretamente
            if (!isPageLoaded)
            {
                // Captura de tela em caso de falha
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                string screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshot.png");
                ss.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(screenshotPath, "Screenshot on Failure");
                Console.WriteLine("Page load verification failed. Screenshot taken.");
                Assert.Fail("A tela de criação de tarefas não foi carregada corretamente.");
            }

            // Seleciona a categoria
            Console.WriteLine("Selecting category...");
            _preencherTarefaPage.SelecionarCategoria();

            // Seleciona a frequência
            Console.WriteLine("Selecting frequency...");
            _preencherTarefaPage.SelecionarFrequencia();

            // Seleciona a gravidade
            Console.WriteLine("Selecting severity...");
            _preencherTarefaPage.SelecionarGravidade();

            // Seleciona a prioridade
            Console.WriteLine("Selecting priority...");
            _preencherTarefaPage.SelecionarPrioridade();

            // Preenche os dados da tarefa com informações fictícias
            Console.WriteLine("Filling task data...");
            _preencherTarefaPage.PreencherDadosDaTarefa();

            // Clica no botão "Finalizar"
            Console.WriteLine("Clicking 'Finalizar' button...");
            _finalizarCracaoPage.ClickFinalizarButton();

            // Espera 5 segundos antes de fechar o navegador
            Console.WriteLine("Waiting for 5 seconds before closing...");
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            Console.WriteLine("Browser closed.");
        }
    }
}

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
    public class ExportarTarefasTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private VerTarefasPage _verTarefasPage;
        private ImprimirTarefasPage _imprimirTarefasPage;
        private ExportarCsvPage _exportarCsvPage;
        private ExportarExcelPage _exportarExcelPage;
        private WebDriverSetup _webDriverSetup;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<ExportarTarefasTests>(); // Acessa as credenciais armazenadas

            _configuration = builder.Build();

            _webDriverSetup = new WebDriverSetup();
            _driver = _webDriverSetup.InitializeWebDriver();
            _loginPage = new LoginPage(_driver);
            _verTarefasPage = new VerTarefasPage(_driver);
            _imprimirTarefasPage = new ImprimirTarefasPage(_driver);
            _exportarCsvPage = new ExportarCsvPage(_driver);
            _exportarExcelPage = new ExportarExcelPage(_driver);
            NavigateToLoginPage();
        }

        private void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br");
            Console.WriteLine("Navigated to login page.");
        }

        [Test]
        public void TestExportarEImprimirTarefas()
        {
            string username = _configuration["Mantis:Username"];
            string password = _configuration["Mantis:Password"];

            try
            {
                Console.WriteLine("Attempting to log in...");
                _loginPage.Login(username, password);

                // Espera 8 segundos
                Thread.Sleep(8000);
                Console.WriteLine("Waited for 8 seconds.");

                // Clica no menu "Ver Tarefas"
                Console.WriteLine("Clicking 'Ver Tarefas' menu...");
                _verTarefasPage.ClickVerTarefasMenu();
                CaptureScreenshot("AfterClickingVerTarefasMenu");

                // Seleciona ao menos 3 tarefas
                Console.WriteLine("Selecting at least 3 tasks...");
                _exportarExcelPage.SelecionarTarefas();
                CaptureScreenshot("AfterSelectingTasksForExcel");

                // Clica no botão "Exportação para Excel"
                Console.WriteLine("Clicking 'Exportação para Excel' button...");
                _exportarExcelPage.ClickExportarExcelButton();

                // Espera 5 segundos
                Console.WriteLine("Waiting for 5 seconds before next action...");
                Thread.Sleep(5000);

                // Seleciona ao menos 3 tarefas (necessário selecionar novamente se a página recarregar)
                Console.WriteLine("Selecting at least 3 tasks...");
                _exportarCsvPage.SelecionarTarefas();
                CaptureScreenshot("AfterSelectingTasksForCSV");

                // Clica no botão "Exportar para Arquivo CSV"
                Console.WriteLine("Clicking 'Exportar para Arquivo CSV' button...");
                _exportarCsvPage.ClickExportarCsvButton();

                // Espera 5 segundos
                Console.WriteLine("Waiting for 5 seconds before next action...");
                Thread.Sleep(5000);

                // Clica no botão "Imprimir Tarefas"
                Console.WriteLine("Clicking 'Imprimir Tarefas' button...");
                _imprimirTarefasPage.ClickImprimirTarefasButton();
                CaptureScreenshot("AfterClickingImprimirTarefasButton");

                // Seleciona ao menos 3 tarefas na tela de impressão
                Console.WriteLine("Selecting at least 3 tasks on print page...");
                _imprimirTarefasPage.SelecionarTarefas();
                CaptureScreenshot("AfterSelectingTasksForPrint");

                // Clica no botão de exportação para Word
                Console.WriteLine("Clicking 'Exportar para Word' button...");
                _imprimirTarefasPage.ClickExportarWordButton();

                // Espera 3 segundos antes de clicar no botão de abrir no Word Web
                Console.WriteLine("Waiting for 3 seconds before next action...");
                Thread.Sleep(3000);

                // Clica no botão de abrir no Word Web
                Console.WriteLine("Clicking 'Open in Word Web' button...");
                _imprimirTarefasPage.ClickOpenInWordWebButton();

                // Espera 5 segundos antes de fechar o navegador
                Console.WriteLine("Waiting for 5 seconds before closing...");
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                // Captura de tela em caso de falha
                CaptureScreenshot("TestFailure");
                Console.WriteLine("Test failed. Screenshot taken.");
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        private void CaptureScreenshot(string stepName)
        {
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            string screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, $"{stepName}.png");
            ss.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotPath, $"Screenshot at {stepName}");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            Console.WriteLine("Browser closed.");
        }
    }
}

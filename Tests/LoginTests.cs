using NUnit.Framework;
using OpenQA.Selenium;
using MantisAutomation.Pages;
using MantisAutomation.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MantisAutomation.Tests
{
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private WebDriverSetup _webDriverSetup;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<LoginTests>(); // Acessa as credenciais armazenadas

            _configuration = builder.Build();

            _webDriverSetup = new WebDriverSetup();
            _driver = _webDriverSetup.InitializeWebDriver();
            _loginPage = new LoginPage(_driver);
            NavigateToLoginPage();
        }

        private void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("http://mantis-prova.base2.com.br");
        }

        [Test]
        public void TestValidLogin()
        {
            string username = _configuration["Mantis:Username"];
            string password = _configuration["Mantis:Password"];

            _loginPage.Login(username, password);
            bool isLoginSuccessful = _loginPage.IsLoginSuccessful();

            // Captura de tela em caso de falha
            if (!isLoginSuccessful)
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                string screenshotPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, "screenshot.png");
                ss.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(screenshotPath, "Screenshot on Failure");
            }

            Assert.IsTrue(isLoginSuccessful, "O login falhou.");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}

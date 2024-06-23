using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace MantisAutomation.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private readonly By _usernameField = By.CssSelector("#username");
        private readonly By _passwordField = By.CssSelector("#password");
        private readonly By _loginButton = By.CssSelector("input[type='submit']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public void Login(string username, string password)
        {
            // Inserir o nome de usuário e clicar no botão "Entrar"
            _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField));
            _driver.FindElement(_usernameField).SendKeys(username);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton));
            _driver.FindElement(_loginButton).Click();

            // Esperar o campo de senha aparecer, inserir a senha e clicar no botão "Entrar" novamente
            _wait.Until(ExpectedConditions.ElementIsVisible(_passwordField));
            _driver.FindElement(_passwordField).SendKeys(password);
            _wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton));
            _driver.FindElement(_loginButton).Click();
        }

        public bool IsLoginSuccessful()
        {
            // Adicionando uma espera explícita para verificar se o título da página está correto
            _wait.Until(ExpectedConditions.TitleContains("Minha Visão - MantisBT"));
            return _driver.Title.Contains("Minha Visão - MantisBT");
        }
    }
}
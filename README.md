# Automação MantisBT

Suite de Testes Automatizados para MantisBT usando Selenium e C#

## Visão Geral do Projeto

Este projeto demonstra a automação do sistema de rastreamento de bugs "Mantis" usando Selenium WebDriver e NUnit. O objetivo é validar funcionalidades da plataforma, garantindo a qualidade e a funcionalidade do sistema.


## Estrutura do Projeto

/MantisAutomation
|-- /Pages
| |-- LoginPage.cs
| |-- CriarTarefaBotaoPage.cs
| |-- PreencherTarefaPage.cs
| |-- FinalizarCracaoPage.cs
| |-- VerTarefasPage.cs
| |-- ImprimirTarefasPage.cs
| |-- ExportarCsvPage.cs
| |-- ExportarExcelPage.cs
|-- /Tests
| |-- LoginTests.cs
| |-- CriarTarefaTests.cs
| |-- ExportarTarefasTests.cs
|-- /Utils
| |-- WebDriverSetup.cs
|-- MantisAutomation.csproj
|-- MantisAutomation.sln



## Tecnologias Utilizadas

- **Linguagem de Programação**: C#
- **Framework de Testes**: NUnit
- **Ferramenta de Automação**: Selenium WebDriver
- **Gerenciador de Dependências**: NuGet
- **IDE**: Visual Studio Code
- **Navegador**: Google Chrome
- **WebDriver**: ChromeDriver


## Configuração do Ambiente

### Pré-requisitos

1. **Instalar o .NET SDK**
   - Baixe e instale o .NET SDK do site oficial.
   

2. **Instalar o Google Chrome**
   - Certifique-se de que o Google Chrome está instalado e atualizado.


3. **Baixar o ChromeDriver**
   - Baixe a versão correspondente do ChromeDriver [aqui](https://sites.google.com/a/chromium.org/chromedriver/downloads).
   - Extraia o executável e adicione seu caminho ao PATH do sistema.


### Configuração do Projeto

1. **Clonar o repositório**
   ```sh
   git clone https://github.com/seu-usuario/mantis-automation.git
   cd mantis-automation

2. **Restaurar dependências do projeto**

Use o comando dotnet restore


3. **Instalando Bibliotecas e Pacotes**

**As dependências necessárias estão definidas no arquivo MantisAutomation.csproj.**


**Aqui estão os principais pacotes utilizados:**

NUnit: Framework de testes

NUnit3TestAdapter: Adaptador para executar testes com NUnit

Microsoft.NET.Test.Sdk: Suporte para testes em .NET

Selenium.WebDriver: Biblioteca do Selenium WebDriver

Selenium.WebDriver.ChromeDriver: ChromeDriver para Selenium

Selenium.Support: Suporte adicional para Selenium

DotNetSeleniumExtras.WaitHelpers: Auxiliares para esperas explícitas no Selenium


4. **Executando os Testes**

Para executar os testes, use o seguinte comando: 
dotnet test

Para rodar um caso específico, use o comando dotnet test com a opção --filter.
dotnet test --filter FullyQualifiedName~Namespace.NomeDaClasse.NomeDoTeste

5. **Contribuindo**
Para contribuir com este projeto:

Faça um fork do repositório.
Crie uma branch para sua funcionalidade (git checkout -b feature/nova-funcionalidade).
Faça commit das suas alterações (git commit -m 'Adicionar nova funcionalidade').
Faça push para a branch (git push origin feature/nova-funcionalidade).
Abra um Pull Request.


Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo LICENSE para mais detalhes.


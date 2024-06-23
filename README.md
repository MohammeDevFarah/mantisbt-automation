# MantisBT Automation

Automated Test Suite for MantisBT using Selenium and C#

## Project Overview

This project demonstrates the automation of the "Mantis" bug tracking system using Selenium WebDriver and NUnit. The objective is to validate critical functionalities of the platform, ensuring the quality and functionality of the system.

## Project Structure

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


## Technologies Used

- **Programming Language**: C#
- **Test Framework**: NUnit
- **Automation Tool**: Selenium WebDriver
- **Dependency Manager**: NuGet
- **IDE**: Visual Studio Code
- **Browser**: Google Chrome
- **WebDriver**: ChromeDriver

## Environment Setup

### Prerequisites

1. **Install .NET SDK**
   - Download and install the .NET SDK from the official website.
   
2. **Install Google Chrome**
   - Ensure that Google Chrome is installed and updated.

3. **Download ChromeDriver**
   - Download the corresponding version of ChromeDriver [here](https://sites.google.com/a/chromium.org/chromedriver/downloads).
   - Extract the executable and add its path to your system PATH.

### Project Configuration

1. **Clone the repository**
   ```sh
   git clone https://github.com/seu-usuario/mantis-automation.git
   cd mantis-automation

2. **Restore project dependencies**

dotnet restore

Installing Libraries and Packages
The required dependencies are defined in the MantisAutomation.csproj file. Here are the main packages used:

NUnit: Test framework
NUnit3TestAdapter: Adapter to run tests with NUnit
Microsoft.NET.Test.Sdk: Support for .NET testing
Selenium.WebDriver: Selenium WebDriver library
Selenium.WebDriver.ChromeDriver: ChromeDriver for Selenium
Selenium.Support: Additional support for Selenium
DotNetSeleniumExtras.WaitHelpers: Helpers for explicit waits in Selenium

To restore all dependencies, run:

dotnet restore


Running the Tests
To run the tests, use the following command:

dotnet test


Contributing
To contribute to this project:

Fork the repository.
Create a branch for your feature (git checkout -b feature/new-feature).
Commit your changes (git commit -m 'Add new feature').
Push to the branch (git push origin feature/new-feature).
Open a Pull Request.

License
This project is licensed under the MIT License - see the LICENSE file for details.
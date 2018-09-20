using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2
{
    public class WebDriver
    {
        public static IWebDriver driver {get;set;}

        [SetUp]
        public void SetUp()
        {
            String IndicadorGrid = ConfigurationManager.AppSettings["IndicadorGrid"].ToString();


            if (IndicadorGrid == "N")
            {
                driver = new ChromeDriver(@"C:\");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Navigate().GoToUrl("http://testlink.claudinei.base2.com.br/login.php");
                driver.Manage().Window.Maximize();
            }
            else
            {
                string navegador = ConfigurationManager.AppSettings["NavegadorDefault"].ToString();
                string nodeURL = ConfigurationManager.AppSettings["IpHub"].ToString();

                switch (navegador)
                {

                    case ("firefox"):
                        FirefoxOptions firefox = new FirefoxOptions();
                        driver = new RemoteWebDriver(new Uri(nodeURL), firefox.ToCapabilities());
                        break;
                    case ("chrome"):
                        ChromeOptions chrome = new ChromeOptions();
                        driver = new RemoteWebDriver(new Uri(nodeURL), chrome.ToCapabilities());
                        break;
                    case ("ie"):
                        OperaOptions opera = new OperaOptions();
                        

                        driver = new RemoteWebDriver(new Uri(nodeURL), opera.ToCapabilities());
                        break;
                }

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Navigate().GoToUrl("http://testlink.claudinei.base2.com.br/login.php");
                driver.Manage().Window.Maximize();


            }     //fim void

        }
    

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
            driver = null;
        }//fim void
         
    }
}

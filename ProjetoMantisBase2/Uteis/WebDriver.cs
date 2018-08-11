using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
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
              driver = new ChromeDriver(@"C:\");
            // ChromeOptions chrome = new ChromeOptions();
          //  driver = new RemoteWebDriver(new Uri("http://172.17.0.2:4444/wd/hub"), chrome.ToCapabilities());

            driver.Navigate().GoToUrl("http://testlink.claudinei.base2.com.br/login.php");

           driver.Manage().Window.Maximize();

        }//fim void

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }//fim void


            
    }


}

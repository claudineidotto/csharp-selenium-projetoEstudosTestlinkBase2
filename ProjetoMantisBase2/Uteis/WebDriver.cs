using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

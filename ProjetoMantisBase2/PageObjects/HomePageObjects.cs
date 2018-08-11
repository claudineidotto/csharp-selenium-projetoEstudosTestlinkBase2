using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class HomePagePageObjects :WebDriver
    {

        public HomePagePageObjects() {


        }

        #region Mapeamento
        public IWebElement msgTestLink => driver.FindElement(By.XPath("//span[3]"));
        public IWebElement btnLogout => driver.FindElement(By.CssSelector("img[title=\"Logout\"]"));
        public IWebElement btnCustomFiels => driver.FindElement(By.LinkText("Gerenciar Campos Personalizados"));
        #endregion

        SeleniumUteis uteis = new SeleniumUteis();
        public void verificaAcessoMyView()
        {       
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            //   Assert.AreEqual("System", viewSystem.Text);
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["titlebar"].ToString());
            Assert.AreEqual("TestLink 1.9.13 (Stormbringer)", msgTestLink.Text);
        }
        public void acessoCustomFields() {
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnCustomFiels);
        }
    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class MyViewPageObjects :WebDriver
    {

        public MyViewPageObjects() {

            PageFactory.InitElements(WebDriver.driver, this);

        }

        [FindsBy(How = How.LinkText, Using = "Logout")]
        public IWebElement menuLogout { get; set; }


        public void verificaAcessoMyView() {
            WebDriverWait espera = new WebDriverWait(WebDriver.driver, TimeSpan.FromSeconds(10));
            espera.Until(ExpectedConditions.ElementToBeClickable(menuLogout));

            Assert.AreEqual("Logout", menuLogout.Text);

        }


    }
}

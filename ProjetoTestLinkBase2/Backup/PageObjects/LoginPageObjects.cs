﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    public class LoginPageObjects : WebDriver
    {
        public LoginPageObjects() {
        }

        #region Mapeamento

        public IWebElement TxtLogin => driver.FindElement(By.Id("login"));

        public IWebElement txtPassword => driver.FindElement(By.Name("tl_password"));

        public IWebElement btnLogin => driver.FindElement(By.Name("login_submit"));

        public IWebElement msgErroLogin => driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='New User?'])[1]/preceding::div[2]"));
        public IWebElement msgLogin => driver.FindElement(By.CssSelector("div.messages_rounded"));
        #endregion

        SeleniumUteis uteis = new SeleniumUteis();

        public void realizalogin(string username, string password) {
            uteis.preencheCampoInput(TxtLogin, username);
            uteis.preencheCampoInput(txtPassword, password);
            uteis.ClicaBotao(btnLogin);
        }
        public void VerificaAcessoPaginaLogin()
        {
            uteis.EsperaElemento(btnLogin);
        }
        public void verificaLoginFalha() {
            uteis.EsperaElemento(msgErroLogin);
            Assert.AreEqual("Try again! Wrong login name or password!",msgErroLogin.Text);
        }
        public void verificaLogout()
        {
            uteis.EsperaElemento(msgLogin);
            Assert.AreEqual("Please log in ...", driver.FindElement(By.CssSelector("div.messages_rounded")).Text);
        }
    }
}

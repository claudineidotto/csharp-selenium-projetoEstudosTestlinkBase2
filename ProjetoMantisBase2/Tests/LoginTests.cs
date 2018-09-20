using System;
using System.Configuration;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;

namespace ProjetoTestLinkBase2
{
 
   // [Parallelizable(ParallelScope.All)]
    public class LoginTests : WebDriver
    {
        [Category("Página Login"),Test]
        public void LoginFalha()
        {
             LoginPageObjects login = new LoginPageObjects();
            login.VerificaAcessoPaginaLogin();
            login.realizalogin(ConfigurationManager.AppSettings["username.false"].ToString(), ConfigurationManager.AppSettings["password.false"].ToString());
            login.verificaLoginFalha();
        }

        [Category ("Página Login"),Test]  
        public void LoginSucesso()
        {    
                LoginPageObjects login = new LoginPageObjects();
                HomePagePageObjects homepage = new HomePagePageObjects();
                login.realizalogin( ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());    
                homepage.verificaAcessoMyView();            
        }

        [Category("Página Login"), Test]
        public void Logout()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.realizaLogout();
            login.verificaLogout();
            
        }
    }
}

using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;

namespace ProjetoTestLinkBase2
{
    
    
    public class LoginTests : WebDriver
    {
        [Test]
        public void LoginFalha()
        {
          
            string username = "claudinei.o";
            string password = "xxx";

            LoginPageObjects login = new LoginPageObjects();

            login.preencheLogin(username);
            login.preencheSenha(password);
            login.clicaLogin();
            login.verificaLoginFalha();
          

            Thread.Sleep(1000);




        }

        [Test]
        public void LoginSucesso()
        {

          
                string username = "claudinei.oliveira";
                string password = "izabella774411";

                LoginPageObjects login = new LoginPageObjects();
                MyViewPageObjects myview = new MyViewPageObjects();
                login.preencheLogin(username);
                login.preencheSenha(password);
                login.clicaLogin();
                myview.verificaAcessoMyView();

                Thread.Sleep(1000);


        }


    }
}

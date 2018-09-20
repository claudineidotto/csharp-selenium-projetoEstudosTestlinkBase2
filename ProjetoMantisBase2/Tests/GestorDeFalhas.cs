using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProjetoMantisBase2.PageObjects;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMantisBase2.Tests
{
    class GestorDeFalhas : WebDriver 
    {
        [Category("Gestor de Falhas"), Test]
        public void CriarGestorDeFalhas()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GestorDeFalhasPageObjects gestordefalhas = new GestorDeFalhasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGestorFalhas();
            gestordefalhas.CriarGestorFalhas();
        }

        [Category("Gestor de Falhas"), Test]
        public void DeletarGestorDeFalhas()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GestorDeFalhasPageObjects gestordefalhas = new GestorDeFalhasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGestorFalhas();
            gestordefalhas.DeletarGestorFalhas();
        }
        [Category("Gestor de Falhas"), Test]
        public void EditarGestorDeFalhas()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GestorDeFalhasPageObjects gestordefalhas = new GestorDeFalhasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGestorFalhas();
            gestordefalhas.EditarGestorFalhas();
        }
/*        [Category("Gestor de Falhas"), Test]
        public void VerificarConexao()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GestorDeFalhasPageObjects gestordefalhas = new GestorDeFalhasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGestorFalhas();
            gestordefalhas.VerificarConexao();
        }
        */
        /*  [Category("Gestor de Falhas"), Test]
          public void OrdenarFormaCrescenteNomeGestorfalhas()
          {
              LoginPageObjects login = new LoginPageObjects();
              HomePagePageObjects homepage = new HomePagePageObjects();
              GestorDeFalhasPageObjects gestordefalhas = new GestorDeFalhasPageObjects();

              login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
              homepage.acessoGestorFalhas();
              gestordefalhas.CriarGestorFalhas();
              gestordefalhas.OrdenaNomeCrescente(); 

          }

          [Category("Gestor de Falhas"), Test]
          public void OrdenarFormaDecrescenteNomeGestorfalhas()
          {
              LoginPageObjects login = new LoginPageObjects();
              HomePagePageObjects homepage = new HomePagePageObjects();
              GestorDeFalhasPageObjects gestordefalhas = new GestorDeFalhasPageObjects();

              login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
              homepage.acessoGestorFalhas();
              gestordefalhas.CriarGestorFalhas();
              gestordefalhas.OrdenaNomeDecrescente();
          }*/




    }
}

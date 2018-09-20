using NUnit.Framework;
using ProjetoMantisBase2.PageObjects;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMantisBase2.Tests
{
    public class GerenciarPlanoTeste :WebDriver
    {
        [Category("Gerenciamento do Plano de Teste"), Test]
        public void CriarPlanoTestesInativo()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarPlanoTestePageObjects GerenciarPlanoTeste = new GerenciarPlanoTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();
            GerenciarPlanoTeste.CriarPlanoTesteInativo();
        }
        [Category("Gerenciamento do Plano de Teste"), Test]
        public void CriarPlanoTestesAtivo()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarPlanoTestePageObjects GerenciarPlanoTeste = new GerenciarPlanoTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();
            GerenciarPlanoTeste.CriarPlanoTesteAtivo();
        }

        [Category("Gerenciamento do Plano de Teste"), Test]
        public void EditarPlanoTestes()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarPlanoTestePageObjects GerenciarPlanoTeste = new GerenciarPlanoTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();
            GerenciarPlanoTeste.EditarPlanoTeste();
        }
        [Category("Gerenciamento do Plano de Teste"), Test]
        public void DeletarPlanoTestes()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarPlanoTestePageObjects GerenciarPlanoTeste = new GerenciarPlanoTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();
            GerenciarPlanoTeste.DeletarPlanoTeste();
        }

        [Category("Gerenciamento do Plano de Teste"), Test]
        public void AtivarPlanoTestes()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarPlanoTestePageObjects GerenciarPlanoTeste = new GerenciarPlanoTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();
            GerenciarPlanoTeste.AtivarPlanoTeste();
        }

        [Category("Gerenciamento do Plano de Teste"), Test]
        public void DesativarPlanoTestes()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarPlanoTestePageObjects GerenciarPlanoTeste = new GerenciarPlanoTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();
            GerenciarPlanoTeste.DesativarPlanoTeste();
        }

    }
}

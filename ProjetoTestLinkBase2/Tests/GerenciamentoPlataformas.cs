using NUnit.Framework;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Tests
{
    class GerenciamentoPlataformas :WebDriver
    {
        [Category("Gerenciamento de Plataformas"), Test]

        public void CriarPlataforma()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciamentoPlataformasPageObjects gerenciamentoplataformas = new GerenciamentoPlataformasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciamentoPlataformas();
            gerenciamentoplataformas.CriarPlataforma();
        }
        [Category("Gerenciamento de Plataformas"), Test]
        public void DeletarPlataforma()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciamentoPlataformasPageObjects gerenciamentoplataformas = new GerenciamentoPlataformasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciamentoPlataformas();
            gerenciamentoplataformas.DeletarPlataforma();
        }
        [Category("Gerenciamento de Plataformas"), Test]
        public void EditarPlataforma()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciamentoPlataformasPageObjects gerenciamentoplataformas = new GerenciamentoPlataformasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciamentoPlataformas();
            gerenciamentoplataformas.EditarPlataforma();
        }
    }
}

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
    
    class GerenciarProjetos : WebDriver
    {
        [Category("Gerenciador de Projetos"), Test]
        public void CriarGerenciarProjeto()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.CriarProjeto();
        }

        [Category("Gerenciador de Projetos"), Test]
        public void FiltroGerenciarProjeto()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.filtrarProjeto();
        }

        [Category("Gerenciador de Projetos"), Test]
        public void ResetarFiltroGerenciarProjeto()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.ResetarfiltroProjeto();


        }

        [Category("Gerenciador de Projetos"), Test]
        public void DeletarProjetoTeste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.DeletarProjetoTeste();


        }


        [Category("Gerenciador de Projetos"), Test]
        public void DesativarProjetoTeste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.DesativarProjetoTeste();


        }

        [Category("Gerenciador de Projetos"), Test]
        public void AtivarProjetoTeste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.AtivarProjetoTeste();
        }

        [Category("Gerenciador de Projetos"), Test]
        public void AtivarRequisitosProjetoTeste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.AtivarRequisitosProjetoTeste();
        }
        [Category("Gerenciador de Projetos"), Test]
        public void DesativarRequisitosProjetoTeste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciadorprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();
            gerenciadorprojetos.DesativarRequisitosProjetoTeste();
        }


    }

}

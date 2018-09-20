using NUnit.Framework;
using ProjetoMantisBase2.PageObjects;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Tests
{
    
  //  [Parallelizable(ParallelScope.All)]
    public class MyViewTests   : WebDriver
    {
        [Category("Home Page"), Test]
        public void AcessoCamposPesonalizados() {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campospersonalizados = new CamposPersonalizadosPageObjects();
            
            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            
        }

        [Category("Home Page"), Test]
        public void AcessoGestorFalhas()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GestorDeFalhasPageObjects campospersonalizados = new GestorDeFalhasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGestorFalhas();


        }

        [Category("Home Page"), Test]
        public void AcessoGerenciadorProjetos()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciarProjetosPageObjects gerenciarprojetos = new GerenciarProjetosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarProjetos();

        }
        [Category("Home Page"), Test]
        public void AcessoPermissaoUsuario()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();

        }

        [Category("Home Page"), Test]
        public void AcessoSelecionarCamposPersonalizados()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            SelecionarCamposPersonalizadosPageObjects selecionarcampos = new SelecionarCamposPersonalizadosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoSelecionarCamposPersonalizados();

        }

        [Category("Home Page"), Test]
        public void AcessoPalavraChave()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PalavraChavePageObjects palavrachave = new PalavraChavePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPalavraChave();

        }
        [Category("Home Page"), Test]
        public void AcessoGerenciamentoPlataformas()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            GerenciamentoPlataformasPageObjects gerenciamentoplataformas = new GerenciamentoPlataformasPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciamentoPlataformas();

        }
        [Category("Home Page"), Test]
        public void AcessoEspecificarCasosTeste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            EspecificarCasosTestePageObjects especificarcasosteste = new EspecificarCasosTestePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoEspecificarCasosTeste();

        }

        [Category("Home Page"), Test]
        public void AcessoCasosTesteUsuario()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCasosTesteUsuario();

        }
        [Category("Home Page"), Test]
        public void AcessoGerenciarPlanoTeste()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoGerenciarPlanosTeste();

        }
        [Category("Home Page"), Test]
        public void AcessoBaseline()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            
            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoBaseline();

        }
    }
}

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
    class PermissaoUsuario:WebDriver
    {

        [Category("Permissão Usuário"), Test]
        public  void CriarUsuarioTesterAtivo() {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.CriarUsuarioTesterAtivo();
         }

        [Category("Permissão Usuário"), Test]
        public void CriarUsuarioTesterInativo()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.CriarUsuarioTesterInativo();
        }

        [Category("Permissão Usuário"), Test]
        public void DesabilitarUsuarioTester()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.DesabilitarUsuarioTester();
        }
        [Category("Permissão Usuário"), Test]
        public void AtivarUsuarioDesabilitadoUsuarioTester()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.AtivarUsuarioDesabilitadoUsuarioTester();
        }
        [Category("Permissão Usuário"), Test]
        public void CriarPerfil()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.CriarPerfil();
        }
        [Category("Permissão Usuário"), Test]
        public void DeletarPerfil()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.DeletarPerfil();
        }
        [Category("Permissão Usuário"), Test]
        public void CriarPerfilSemPermissoes()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.CriarPerfilSemPermissao();
        }

    }
}

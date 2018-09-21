using NUnit.Framework;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.Tests
{
    class DataTestes:WebDriver 
    {
        [Category("DataTest"), Test]
        public void Teste()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            PermissaoUsuarioPageObjects permissaousuario = new PermissaoUsuarioPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoPermissaoUsuario();
            permissaousuario.CriarUsuarioDDT();
         
        }
    }
}

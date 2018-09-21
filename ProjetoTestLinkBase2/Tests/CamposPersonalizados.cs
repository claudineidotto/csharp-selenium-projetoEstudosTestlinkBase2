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
    
    public class CamposPersonalizados : WebDriver
    {
        [Category("Campos Pesonalizados"), Test]
        public void CriarCamposPersonalizados()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campospersonalizados = new CamposPersonalizadosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            campospersonalizados.criarCamposPersonalizados();
        }

        [Category("Campos Pesonalizados"), Test]
        public void DeletarCamposPersonalizados()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campospersonalizados = new CamposPersonalizadosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            campospersonalizados.deletarCamposPersonalizados();

        }
        [Category("Campos Pesonalizados"), Test]
        public void EditarCamposPersonalizados()
        {

            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campospersonalizados = new CamposPersonalizadosPageObjects();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            campospersonalizados.EditarCamposPersonalizados();

        }


    }
}

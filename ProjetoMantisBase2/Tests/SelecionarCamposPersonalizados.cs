using NUnit.Framework;
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
    class SelecionarCamposPersonalizados : WebDriver
    {

        [Category("Selecionar Campos Personalizados"), Test]
        public void AtribuirCamposPesonalizados()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campos = new CamposPersonalizadosPageObjects();
            SelecionarCamposPersonalizadosPageObjects selecionarcampos = new SelecionarCamposPersonalizadosPageObjects();
            string nome = SeleniumUteis.GerarNome();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            nome=campos.criarCamposPersonalizados(nome);
            campos.acessoHomePage();
            homepage.acessoSelecionarCamposPersonalizados();
            selecionarcampos.AtribuirCamposPersonalizados(nome);

        }

        [Category("Selecionar Campos Personalizados"), Test]
        public void RemoverAtribuicaoCamposPesonalizados()
        {
            LoginPageObjects login = new LoginPageObjects();
            HomePagePageObjects homepage = new HomePagePageObjects();
            CamposPersonalizadosPageObjects campos = new CamposPersonalizadosPageObjects();
            SelecionarCamposPersonalizadosPageObjects selecionarcampos = new SelecionarCamposPersonalizadosPageObjects();
            string nome = SeleniumUteis.GerarNome();

            login.realizalogin(ConfigurationManager.AppSettings["username"].ToString(), ConfigurationManager.AppSettings["password"].ToString());
            homepage.acessoCustomFields();
            nome = campos.criarCamposPersonalizados(nome);
            campos.acessoHomePage();
            homepage.acessoSelecionarCamposPersonalizados();
            selecionarcampos.RemoverAtribuicaoCamposPersonalizados(nome);

        }




    }
}

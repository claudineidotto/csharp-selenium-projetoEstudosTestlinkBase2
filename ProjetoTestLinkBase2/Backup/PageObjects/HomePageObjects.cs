using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class HomePagePageObjects :WebDriver
    {

        public HomePagePageObjects() {


        }

        #region Mapeamento
        public IWebElement msgTestLink => driver.FindElement(By.XPath("//span[3]"));
        public IWebElement btnLogout => driver.FindElement(By.CssSelector("img[title=\"Sair\"]"));
        public IWebElement btnCustomFields => driver.FindElement(By.LinkText("Gerenciar Campos Personalizados"));
        public IWebElement btnGestorFalhas => driver.FindElement(By.LinkText("Gerenciar Gestor de Falhas"));
        public IWebElement btnGerenciarProjetos => driver.FindElement(By.LinkText("Gerenciar Projeto de Teste"));
        public IWebElement btnPermissaoUsuario => driver.FindElement(By.LinkText("Permissão do Usuário"));
        public IWebElement btnSelecionarCamposPersonalizados => driver.FindElement(By.LinkText("Selecionar Campos Personalizados"));
        public IWebElement btnPalavraChave => driver.FindElement(By.LinkText("Gerenciar Palavra-chave"));
        public IWebElement btnGerenciamentoPlataformas => driver.FindElement(By.LinkText("Gerenciamento de Plataformas"));
        public IWebElement BtnEspecificarCasosTeste => driver.FindElement(By.LinkText("Especificar Casos de Teste"));
        public IWebElement BtnGerenciarPlanosTeste => driver.FindElement(By.LinkText("Gerenciar Plano de Teste"));
        public IWebElement BtnCasosTesteUsuario => driver.FindElement(By.LinkText("Casos de teste criados por usuário"));
        public IWebElement BtnBaselines => driver.FindElement(By.LinkText("Baselines / Releases"));

        #endregion

        public void verificaAcessoMyView()
        {       
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["titlebar"].ToString());
            Assert.AreEqual("TestLink 1.9.13 (Stormbringer)", msgTestLink.Text);
        }
        public void acessoCustomFields() {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnCustomFields);
            Assert.AreEqual("Campos Personalizados", driver.FindElement(By.CssSelector("h1.title")).Text);

        }

        public void acessoGestorFalhas()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnGestorFalhas);
            Assert.AreEqual("Gestor de Falhas", driver.FindElement(By.CssSelector("th")).Text);

        }

        public void acessoGerenciarProjetos()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnGerenciarProjetos);
            Assert.AreEqual("Search/Filter", driver.FindElement(By.Id("search")).GetAttribute("value"));

        }
        public void acessoPermissaoUsuario()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnPermissaoUsuario);
            Assert.AreEqual("Administração de Usuários - Atribuir papéis", driver.FindElement(By.CssSelector("h1.title")).Text);

        }
        public void acessoSelecionarCamposPersonalizados()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnSelecionarCamposPersonalizados);
            Assert.AreEqual("Atribuir Campos Personalizados - Projeto de Teste : Claudinei", driver.FindElement(By.CssSelector("h1.title")).Text);

        }

        public void acessoPalavraChave()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnPalavraChave);
            Assert.AreEqual("Gerenciamento de Palavra-chave", driver.FindElement(By.CssSelector("h1.title")).Text);

        }
        public void acessoGerenciamentoPlataformas()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(btnGerenciamentoPlataformas);
            Assert.AreEqual("Gerenciamento de Plataformas", driver.FindElement(By.CssSelector("h1.title")).Text);

        }
        public void acessoEspecificarCasosTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(BtnEspecificarCasosTeste);
        }

        public void acessoCasosTesteUsuario()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(BtnCasosTesteUsuario);
            Assert.AreEqual("Projeto: Claudinei - Casos de teste criados por usuário", driver.FindElement(By.CssSelector("h1.title")).Text);
        }

        public void acessoGerenciarPlanosTeste()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(BtnGerenciarPlanosTeste);
            Assert.AreEqual("Gerenciamento do Plano de Teste - Projeto de Teste Claudinei", driver.FindElement(By.CssSelector("h1.title")).Text);

        }


        public void realizaLogout() {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["titlebar"].ToString());
            uteis.ClicaBotao(btnLogout);
        }
        public void acessoBaseline()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().Frame(ConfigurationManager.AppSettings["mainframe"].ToString());
            uteis.ClicaBotao(BtnBaselines);
            Assert.AreEqual("Título:", driver.FindElement(By.CssSelector("th")).Text);

        }

    }
}

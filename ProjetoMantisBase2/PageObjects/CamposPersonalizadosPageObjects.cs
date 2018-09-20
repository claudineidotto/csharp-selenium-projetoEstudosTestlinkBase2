using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoMantisBase2.PageObjects
{
    class CamposPersonalizadosPageObjects : WebDriver
    {

        #region Mapeamento
        public IWebElement acessoCamposP => driver.FindElement(By.CssSelector("h1.title"));
        public IWebElement criarCamposP => driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Suíte de Teste'])[1]/following::input[3]"));
        public IWebElement txt_nome => driver.FindElement(By.CssSelector("input[name =\"cf_name\"]"));
        public IWebElement txt_rotulo => driver.FindElement(By.Name("cf_label"));
        public IWebElement CboxDisponivel => driver.FindElement(By.Id("combo_cf_node_type_id"));
        public IWebElement CboxTipo => driver.FindElement(By.Id("combo_cf_type"));
        public IWebElement CboxHab => driver.FindElement(By.Id("cf_enable_on"));
        public IWebElement CboxMostrar => driver.FindElement(By.Id("cf_show_on_execution"));
        public IWebElement btnDelete => driver.FindElement(By.Name("do_delete"));
        public IWebElement BtnAtualizar => driver.FindElement(By.Name("do_update"));
        public IWebElement btnCofirmarDelete => driver.FindElement(By.Id("ext-gen20"));
        public IWebElement btnAdicionar => driver.FindElement(By.CssSelector("input[name=\"do_update\"]"));
        public IWebElement btnLogo => driver.FindElement(By.CssSelector("img[alt=\"Company logo\"]"));
        #endregion
        

        public void criarCamposPersonalizados()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.EsperaElemento(criarCamposP);
            uteis.ClicaBotao(criarCamposP);
            string nome= SeleniumUteis.GerarNome();
            string rotulo = SeleniumUteis.GerarRotulo();
            uteis.preencheCampoInput(txt_nome, nome);
            uteis.preencheCampoInput(txt_rotulo, rotulo);
            uteis.selecionaRandomicoComboBox(CboxDisponivel);
            uteis.selecionaRandomicoComboBox(CboxTipo);
            uteis.ClicaBotao(btnAdicionar);
            uteis.verificaNomeTabela(nome);
        }
        public string criarCamposPersonalizados(String nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.EsperaElemento(criarCamposP);
            uteis.ClicaBotao(criarCamposP);
            string rotulo = SeleniumUteis.GerarRotulo();
            uteis.preencheCampoInput(txt_nome, nome);
            uteis.preencheCampoInput(txt_rotulo, rotulo);
            uteis.selecionaRandomicoComboBox(CboxDisponivel);
            uteis.selecionaRandomicoComboBox(CboxTipo);
            uteis.ClicaBotao(btnAdicionar);
            uteis.verificaNomeTabela(nome);
            return nome;
        }
        public void deletarCamposPersonalizados()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = criarCamposPersonalizados(nome);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            uteis.ClicaBotao(btnDelete);
            uteis.ClicaBotao(btnCofirmarDelete);
            Assert.AreEqual(null, uteis.confirmaExclusaoTabela(nome));

        }

        public void EditarCamposPersonalizados()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            string nome = SeleniumUteis.GerarNome();
            nome = criarCamposPersonalizados(nome);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            string novonome = SeleniumUteis.GerarNome();
            string novorotulo = SeleniumUteis.GerarRotulo();
            uteis.preencheCampoInput(txt_nome, novonome);
            uteis.preencheCampoInput(txt_rotulo, novorotulo);
            uteis.ClicaBotao(BtnAtualizar);
            Assert.AreEqual(novonome, driver.FindElement(By.LinkText(novonome)).Text.Trim());

        }

        public void acessoHomePage()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("titlebar");//ConfigurationManager.AppSettings["titlebar"].ToString());

            uteis.ClicaBotao(btnLogo);

        }

    }
}

using NUnit.Framework;
using OpenQA.Selenium;
using ProjetoTestLinkBase2;
using ProjetoTestLinkBase2.Uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTestLinkBase2.PageObjects
{
    class GerenciamentoPlataformasPageObjects:WebDriver
    {
        #region Mapeamento
        public IWebElement BtnCriarPlataforma => driver.FindElement(By.Id("create_platform"));
        public IWebElement TxtPlataforma => driver.FindElement(By.Name("name"));
        public IWebElement TxtDescricao => driver.FindElement(By.CssSelector("html.CSS1Compat"));
        public IWebElement BtnSalvar => driver.FindElement(By.Id("submitButton"));
        public IWebElement BtnDeletarSim => driver.FindElement(By.Id("ext-gen20"));

        #endregion

        public void CriarPlataforma()
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnCriarPlataforma);
            string nome = SeleniumUteis.GerarNome();
            uteis.PreencheCampoInput(TxtPlataforma, nome);
          //  uteis.preencheCampoInput(TxtDescricao, nome);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(nome, driver.FindElement(By.LinkText(nome)).Text);
        }

        public void CriarPlataforma(string nome)
        {
            SeleniumUteis uteis = new SeleniumUteis();
            uteis.ClicaBotao(BtnCriarPlataforma);

            uteis.PreencheCampoInput(TxtPlataforma, nome);
         //   uteis.preencheCampoInput(TxtDescricao, nome);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(nome, driver.FindElement(By.LinkText(nome)).Text);
        }
        public void DeletarPlataforma()
        {
            string nome = SeleniumUteis.GerarNome();
            SeleniumUteis uteis = new SeleniumUteis();
            CriarPlataforma(nome);
            uteis.ClicaPosicaoTabela(nome, 2);
            uteis.ClicaBotao(BtnDeletarSim);
            Assert.AreEqual(null, uteis.ConfirmaExclusaoTabela(nome));

        }
        public void EditarPlataforma()
        {
            string nome = SeleniumUteis.GerarNome();
            SeleniumUteis uteis = new SeleniumUteis();
            CriarPlataforma(nome);
            uteis.ClicaBotao(driver.FindElement(By.LinkText(nome)));
            string nomenovo = SeleniumUteis.GerarNome();
            uteis.PreencheCampoInput(TxtPlataforma, nomenovo);
            uteis.ClicaBotao(BtnSalvar);
            Assert.AreEqual(nomenovo, driver.FindElement(By.LinkText(nomenovo)).Text);
        }
    }
}
